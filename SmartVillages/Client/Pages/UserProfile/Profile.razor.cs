﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.UserProfile
{
    public class ProfileBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        [Parameter] public string Id { get; set; }

        public User User { get; set; } = new User();
        public bool ProfileOfSignInUser { get; set; }
        public bool EditingProfileImage { get; set; }
        public string UserOldImage { get; set; }
        public bool Loaded { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Id == "0")
            {
                ProfileOfSignInUser = true;
                User = await LocalStorage.GetItemAsync<User>("user");
                Loaded = true;
            }
            else
            {
                ProfileOfSignInUser = false;
                var response = await Http.GetAsync($"api/users/{Id}");
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    List<User> users = await response.Content.ReadFromJsonAsync<List<User>>();
                    User = users.LastOrDefault();
                    Loaded = true;
                }
            }
            StateHasChanged();
        }

        public async Task UploadFiles(InputFileChangeEventArgs e)
        {
            var entries = e.GetMultipleFiles();
            //Do your validations here
            /*
            Snackbar.Add($"Files with {entries.FirstOrDefault().Size} bytes size are not allowed", Severity.Error);
            Snackbar.Add($"Files starting with letter {entries.FirstOrDefault().Name.Substring(0, 1)} are not recommended", Severity.Warning);
            Snackbar.Add($"This file has the extension {entries.FirstOrDefault().Name.Split(".").Last()}", Severity.Info);
            */

            //get the file
            var file = e.File;
            //read that file in a byte array
            var buffer = new byte[file.Size];
            await file.OpenReadStream(1512000).ReadAsync(buffer);
            //convert byte array to base 64 string
            UserOldImage = User.ProfileImage;
            User.ProfileImage = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";

            EditingProfileImage = true;
            StateHasChanged();
        }

        public async Task CancelUpdateingImage()
        {
            EditingProfileImage = false;
            User.ProfileImage = UserOldImage;
            StateHasChanged();
        }

        public async Task DoUpdateingImage()
        {
            EditingProfileImage = false;
            StateHasChanged();

            var response = await Http.PutAsJsonAsync($"api/users/{User.Id}", User);
            Snackbar.Clear();
            Snackbar.Add("GOOD", Severity.Success);
            await LocalStorage.SetItemAsync("user", User);
        }
    }
}
