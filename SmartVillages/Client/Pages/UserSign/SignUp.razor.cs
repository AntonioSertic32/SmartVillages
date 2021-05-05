using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.UserSign
{
    public class SignUpBase : ComponentBase
    {
        [Parameter] public bool IsLeftOpened { get; set; }
        [Parameter] public EventCallback GoBack { get; set; }
        [Parameter] public EventCallback OpenSignIn { get; set; }
        
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        public List<UserType> UserTypes { get; set; } = new List<UserType>();
        public User exampleModel { get; set; } = new User();

        /*
        protected override async Task OnInitializedAsync()
        {}
        */

        public async Task HandleValidSubmit()
        {
            Console.WriteLine("Valid!");
            Console.WriteLine(exampleModel.FirstName + " " + exampleModel.LastName + " " + exampleModel.Email + " " + exampleModel.Password + " " + exampleModel.TermsAndConditions);
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("Validateing..", Severity.Success);

            await CreateUser();
        }

        public void HandleInvalidSubmit()
        {
            Console.WriteLine("Invalid!");
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("All fields are required!", Severity.Error);
            if(!exampleModel.TermsAndConditions)
                Snackbar.Add("You must agree to terms and conditions!", Severity.Error);
        }

        public async Task CreateUser()
        {
            int user_type = IsLeftOpened ? 2 : 1;
            
            try
            {
                var response = await Http.PostAsJsonAsync($"api/users/postuser/{user_type}", exampleModel);

                Snackbar.Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    Snackbar.Add("Već postoji korisnik s tim email-om ili oib-om.", Severity.Error);
                else
                    Snackbar.Add("Success!", Severity.Success);
            }
            catch (HttpRequestException ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                throw;
            }
        }

        // Password
        public bool isPassVisiable;
        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public void ShowHidePass()
        {
            if(isPassVisiable)
            {
                isPassVisiable = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isPassVisiable = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

    }
}
