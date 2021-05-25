using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        public string TextValue { get; set; }
        public string MessageToSend { get; set; }

        public void OpenMessage()
        {
            NavigationManager.NavigateTo("/index");
        }

        public User User { get; set; }
        public List<Message> MessagesList { get; set; } = new List<Message>();

        protected override async Task OnInitializedAsync()
        {
            User = await localStorage.GetItemAsync<User>("user");

            /*
            User = new User();
            Users.Add(new User { Id = 1, FirstName = "Antonio" });
            Users.Add(new User { Id = 2, FirstName = "Mirko" });
            */
            await GetMessages();
            await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
        }

        public async Task GetMessages()
        {
            try
            {
                var response = await Http.GetAsync($"api/messages/getmessagesbyuser/24/13");

                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    MessagesList = await response.Content.ReadFromJsonAsync<List<Message>>();
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
            Message NewMessage = new Message { Date = DateTime.Now, MessageContent = MessageToSend, Seen = false };

            try
            {
                var response = await Http.PostAsJsonAsync($"api/messages/postmessage/" + User.Id + "/" + 24, NewMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    var message = await response.Content.ReadFromJsonAsync<Message>();
                    MessagesList.Add(message);
                    StateHasChanged();
                    await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
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
    }
}
