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

        public User UserModel { get; set; } = new User();
        public string Message { get; set; } = "";

        protected override Task OnInitializedAsync()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;

            return base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            Snackbar.Clear();
            Snackbar.Add("Validateing..", Severity.Success);

            await CreateUser();
        }

        public void HandleInvalidSubmit()
        {
            Snackbar.Clear();
            Snackbar.Add("All fields are required!", Severity.Error);
            if(!UserModel.TermsAndConditions)
                Snackbar.Add("You must agree to terms and conditions!", Severity.Error);
        }

        public async Task CreateUser()
        {
            int user_type = IsLeftOpened ? 2 : 1;
            
            try
            {
                var response = await Http.PostAsJsonAsync($"api/users/postuser/{user_type}", UserModel);

                Snackbar.Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    Snackbar.Add("Već postoji korisnik s tim email-om ili oib-om.", Severity.Error);
                }
                else
                {
                    Snackbar.Add("<p class='text-center'>SUCCESSFULLY REGISTERED! </br> Please go check you email for further validation.</p>", Severity.Success);
                    await SendEmail();
                    await GoBack.InvokeAsync();
                }
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

        public async Task SendEmail()
        {
            try
            {
                var response = await Http.PostAsJsonAsync($"api/users/SendEmail", UserModel);

                Snackbar.Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    Snackbar.Add("Greška kod slanja emaila.", Severity.Error);
                }
                else
                {
                    Snackbar.Add("Email uspješno poslan.", Severity.Success);
                }
            }
            catch (HttpRequestException ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        /*
        [12:36, 19. 05. 2021.] Antonio: - Kreirati EmailConfirmationCode za tog usera, stavit mu u bazu i poslat u putanji buttona koji dobije na mail
        - Kada dođe na tu stranicu uzme taj Code i pošalje upit na bazu za njega i ak nađe validira ga te ispiše da je validirano
        - Pa kreira pravi SecretCode, upuca ga na bazu i posalje useru na mail
        */

    }
}
