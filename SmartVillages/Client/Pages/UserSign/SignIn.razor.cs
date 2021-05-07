using Microsoft.AspNetCore.Components;
using SmartVillages.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartVillages.Client.Shared;
using SmartVillages.Shared;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;

namespace SmartVillages.Client.Pages.UserSign
{
    public class SignInBase : ComponentBase
    {
        [Parameter] public bool isLeftOpened { get; set; }
        [Parameter] public EventCallback goBack { get; set; }
        [Parameter] public EventCallback OpenSignUp { get; set; }

        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        public UserSignIn UserModel { get; set; } = new UserSignIn();

        /* neka animacija dok se logira */
        public bool Loading { get; set; }

        public async Task GoBack()
        {
            await goBack.InvokeAsync();
        }

        public async Task HandleValidSubmit()
        {
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("Validateing..", Severity.Success);

            await Login();
        }

        public void HandleInvalidSubmit()
        {
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
            Snackbar.Add("All fields are required!", Severity.Error);
        }

        // Password
        public bool isPassVisiable;
        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public void ShowHidePass()
        {
            if (isPassVisiable)
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

        public async Task Login()
        {
            try
            {
                var response = await Http.PostAsJsonAsync($"api/users/login", UserModel);

                Snackbar.Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Snackbar.Add("Unjeli ste pogrešan email ili lozinku", Severity.Error);
                }
                else
                {
                    // SPremiti u local storage ili coochie
                    Snackbar.Add("Success!", Severity.Success);
                    Navigation.NavigateTo("/index");
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
