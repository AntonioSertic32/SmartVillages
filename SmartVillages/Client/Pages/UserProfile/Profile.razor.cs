using Blazored.LocalStorage;
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
        public User User { get; set; } = new User();

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<User>("user");
        }

        public async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEvent)
        {
            //get the file
            var file = inputFileChangeEvent.File;
            //read that file in a byte array
            var buffer = new byte[file.Size];
            await file.OpenReadStream(1512000).ReadAsync(buffer);
            //convert byte array to base 64 string
            User.ProfileImage = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";

            await UploadImage();
            // sprmeim u bazu imageData
            //kad iscitavam samo ubacim u search user.image jel..
        }

        public async Task UploadImage()
        {
            try
            {
                var response = await Http.PutAsJsonAsync($"api/users/{User.Id}", User);

                Snackbar.Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    Snackbar.Add("Error.", Severity.Error);
                }
                else
                {
                    Snackbar.Add("GOOD", Severity.Success);
                    StateHasChanged();
                }
            }
            catch (HttpRequestException ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                throw;
            }
        }

    }
}
