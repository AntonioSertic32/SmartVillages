using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using SmartVillages.Shared;

namespace SmartVillages.Client.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        public User User { get; set; } = new User();

        public string FullName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = await LocalStorage.GetItemAsync<User>("user");
            if (user == null)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            { 
                User = user;
                FullName = User.FirstName + " " + User.LastName;
            }
        }

        public void Logout()
        {
            LocalStorage.RemoveItemAsync("user");
            NavigationManager.NavigateTo("/");
        }

    }
}
