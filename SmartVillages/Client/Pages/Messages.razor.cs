using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using SmartVillages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages
{
    public class MessagesBase : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService localStorage { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }

        public string TextValue { get; set; }
        public string MessageToSend { get; set; }
        public bool LoadingMessage { get; set; }

        public User User { get; set; }
        public List<Message> DirectMessagesList { get; set; } = new List<Message>();
        public List<LastMessage> AllMessagesList { get; set; } = new List<LastMessage>();

        protected override async Task OnInitializedAsync()
        {
            LoadingMessage = true;
            User = await localStorage.GetItemAsync<User>("user");

            /* DOHVACANJE SVIH PORUKA ZA LIJEVU STRANU KOMPONENTE */
            await GetAllMessages();

            /*
            User = new User();
            Users.Add(new User { Id = 1, FirstName = "Antonio" });
            Users.Add(new User { Id = 2, FirstName = "Mirko" });
            */

            /*
            DOHVACANJE POSEBNIH PORUKA
            await GetDirectMessages();
            LoadingMessage = false;
            await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
            */
        }

        public async Task GetAllMessages()
        {
            try
            {
                var response = await Http.GetAsync($"api/messages/getalllastmessages/" + User.Id);

                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    AllMessagesList = await response.Content.ReadFromJsonAsync<List<LastMessage>>();
                    StateHasChanged();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task GetDirectMessages()
        {
            try
            {
                var response = await Http.GetAsync($"api/messages/getmessagesbyuser/24/13");

                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    DirectMessagesList = await response.Content.ReadFromJsonAsync<List<Message>>();
                    StateHasChanged();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task SendMessage()
        {
            if(MessageToSend != "")
            {
                Message NewMessage = new Message { Date = DateTime.Now, MessageContent = MessageToSend, Seen = false };

                try
                {
                    var response = await Http.PostAsJsonAsync($"api/messages/postmessage/" + User.Id + "/" + 24, NewMessage);

                    if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                    {
                        var message = await response.Content.ReadFromJsonAsync<Message>();
                        DirectMessagesList.Add(message);
                        StateHasChanged();
                        await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Snackbar.Add("Message is empty!", Severity.Error);
            }
        }

        public async Task<User> GetUser( int id )
        {
            var response = await Http.GetAsync($"api/users/" + id);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                User = await response.Content.ReadFromJsonAsync<User>();
                return User;
            }

            return null;
        }

        public async Task OpenMessage(User user)
        {
            Console.WriteLine(user.Email);
            //NavigationManager.NavigateTo("/index");
        }
    }
}
