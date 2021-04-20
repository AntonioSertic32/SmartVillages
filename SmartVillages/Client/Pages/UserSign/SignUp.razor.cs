using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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


        public bool success;
        public string[] errors = { };
        public MudTextField<string> pwField1;
        public MudForm form;

        public IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        public string PasswordMatch(string arg)
        {
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }
    }
}
