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
        [Inject] public ISnackbar Snackbar { get; set; }
        public UserSignUp User { get; set; } = new UserSignUp();
        public List<UserType> UserTypes { get; set; } = new List<UserType>();


        protected override Task OnInitializedAsync()
        {
            UserTypes.Add(new UserType { UserTypeId = 1, UserTypeName = "Farmer" });
            UserTypes.Add(new UserType { UserTypeId = 2, UserTypeName = "Customer" });
            return base.OnInitializedAsync();
        }


        public void ValidSignUp()
        {
        }
        public User exampleModel = new User();

        public void HandleValidSubmit()
        {
            Console.WriteLine("Valid!");
            Console.WriteLine(exampleModel.FirstName + " " + exampleModel.LastName + " " + exampleModel.Email + " " + exampleModel.Password + " " + exampleModel.TermsAndConditions);
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("Validateing..", Severity.Success);
        }

        public void HandleInvalidSubmit()
        {
            Console.WriteLine("Invalid!");
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("All fields are required!", Severity.Error);
        }
        
    }
}
