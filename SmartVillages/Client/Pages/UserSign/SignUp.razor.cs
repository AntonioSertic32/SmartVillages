using Microsoft.AspNetCore.Components;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.UserSign
{
    public class SignUpBase : ComponentBase
    {
        [Parameter] public bool IsLeftOpened { get; set; }
        [Parameter] public EventCallback GoBack { get; set; }

        public UserSignUp User { get; set; } = new UserSignUp();
        public List<UserType> UserTypes { get; set; } = new List<UserType>();

        protected override Task OnInitializedAsync()
        {
            UserTypes.Add(new UserType { UserTypeId = 1, UserTypeName = "Farmer" });
            UserTypes.Add(new UserType { UserTypeId = 2, UserTypeName = "Customer" });
            return base.OnInitializedAsync();
        }

        public async Task Close()
        {
            await GoBack.InvokeAsync();
        }

        public void ValidSignUp()
        {
            Console.WriteLine("Sign me up!!");
        }
    }
}
