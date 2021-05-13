using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.UserSign
{
    public class HomeBase : ComponentBase
    {
        [Inject] IJSRuntime JsRuntime { get; set; } 
        public bool leftSignInOpened { get; set; }
        public bool leftSignUpOpened { get; set; }
        public bool rightSignInOpened { get; set; }
        public bool rightSignUpOpened { get; set; }
        public bool isLeftOpened { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] ILocalStorageService localStorage { get; set; }

        public UserSignIn User { get; set; } = new UserSignIn();


        protected override async Task OnInitializedAsync()
        {
            var user = await localStorage.GetItemAsync<User>("user");
            if (user != null)
            {
                Navigation.NavigateTo("/index");
            }
        }

        public void OpenLeftSignIn()
        {
            CloseAll();
            leftSignInOpened = true;
            isLeftOpened = false;
            GoUp();
            StateHasChanged();
        }

        public void OpenLeftSignUp()
        {
            CloseAll();
            leftSignUpOpened = true;
            isLeftOpened = false;
            GoUp();
            StateHasChanged();
        }

        public void OpenRightSignIn()
        {
            CloseAll();
            rightSignInOpened = true;
            isLeftOpened = true;
            GoDown();
            StateHasChanged();
        }

        public void OpenRightSignUp()
        {
            CloseAll();
            rightSignUpOpened = true;
            isLeftOpened = true;
            GoDown();
            StateHasChanged();
        }

        public void CloseAll()
        {
            leftSignInOpened = false;
            leftSignUpOpened = false;
            rightSignInOpened = false;
            rightSignUpOpened = false;
        }

        public void GoBackPressed()
        {
            CloseAll();
            StateHasChanged();
        }

        public Task GoUp()
        {
            JsRuntime.InvokeVoidAsync("scrollToElementId", "top-contact");
            return Task.CompletedTask;
        }
        public Task GoDown()
        {
            JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom-contact");
            return Task.CompletedTask;
        }

        public void OpenSignIn()
        {
            if (isLeftOpened)
                OpenRightSignIn();
            else
                OpenLeftSignIn();
        }

        public void OpenSignUp()
        {
            if (isLeftOpened)
                OpenRightSignUp();
            else
                OpenLeftSignUp();
        }
    }
}
