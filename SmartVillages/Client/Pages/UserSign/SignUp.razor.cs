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
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        public User User { get; set; } = new User();
        public List<UserType> UserTypes { get; set; } = new List<UserType>();

        public User[] users { get; set; }
        public User exampleModel { get; set; } = new User();


        protected override async Task OnInitializedAsync()
        {
            UserTypes.Add(new UserType { UserTypeId = 1, UserTypeName = "Farmer" });
            UserTypes.Add(new UserType { UserTypeId = 2, UserTypeName = "Customer" });
        }

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
        }

        public async Task CreateUser()
        {
            /*
            if (IsLeftOpened)
                exampleModel.UserType = UserTypes[0];
            else
                exampleModel.UserType = UserTypes[1];
            */
            try
            {
                var response = await Http.PostAsJsonAsync("api/users", exampleModel);
                Console.WriteLine(response.StatusCode);
                Snackbar.Clear();
                Snackbar.Add("Success!", Severity.Success);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
