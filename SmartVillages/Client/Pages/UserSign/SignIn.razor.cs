using Microsoft.AspNetCore.Components;
using SmartVillages.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartVillages.Client.Shared;
using SmartVillages.Shared;

namespace SmartVillages.Client.Pages.UserSign
{
    public class SignInBase : ComponentBase
    {
        [Parameter] public bool isLeftOpened { get; set; }
        [Parameter] public EventCallback goBack { get; set; }
        [Parameter] public EventCallback OpenSignUp { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }

        public User User { get; set; }
        public UserType UserType { get; set; }

        public bool loading { get; set; }

        public async Task Login(bool isCustomer)
        {
            //NavigationManager.NavigateTo("/index");
        }

        public async Task GoBack()
        {
            await goBack.InvokeAsync();
        }

    }
}
