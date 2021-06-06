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
        [Parameter] public string Id { get; set; }
        [Inject] ILocalStorageService localStorage { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }

        public string TextValue { get; set; }
        public string MessageToSend { get; set; }
        public bool LoadingMessage { get; set; }
        public bool MessageOpened { get; set; } = false;
        public User OpenedUser { get; set; }

        public bool Found { get; set; }

        public User User { get; set; }
        public List<Message> DirectMessagesList { get; set; } = new List<Message>();
        public List<LastMessage> AllMessagesList { get; set; } = new List<LastMessage>();

        protected override async Task OnInitializedAsync()
        {
            User = await localStorage.GetItemAsync<User>("user");
            /* DOHVACANJE SVIH PORUKA ZA LIJEVU STRANU KOMPONENTE */
            await GetAllMessages();

            foreach(var me in AllMessagesList)
            {
                // pogledat jel ima sa userom pod ovim id-om
                if (me.User.Id == int.Parse(Id))
                {
                    // otvoriti te poruke
                    Found = true;
                    await OpenMessage(me);
                    break;
                }
            }
            if(!Found && Id != "0")
            {
                // ili samo ispisati informacije (otvaranje nove poruke)
                await OpenNewMessage();
            }

            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Filled;
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
            LoadingMessage = true;
            try
            {
                var response = await Http.GetAsync($"api/messages/getmessagesbyuser/{OpenedUser.Id}/{User.Id}");

                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    DirectMessagesList = await response.Content.ReadFromJsonAsync<List<Message>>();
                    LoadingMessage = false;
                    StateHasChanged();
                    await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task SendMessage()
        {
            if(!string.IsNullOrEmpty(MessageToSend) && !string.IsNullOrWhiteSpace(MessageToSend))
            {
                Message NewMessage = new Message { Date = DateTime.Now, MessageContent = MessageToSend, Seen = false };

                try
                {
                    var response = await Http.PostAsJsonAsync($"api/messages/postmessage/" + User.Id + "/" + OpenedUser.Id, NewMessage);

                    if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                    {
                        var message = await response.Content.ReadFromJsonAsync<Message>();
                        DirectMessagesList.Add(message);
                        MessageToSend = "";
                        StateHasChanged();
                        await JsRuntime.InvokeVoidAsync("scrollToElementId", "bottom_message");
                        await GetAllMessages();
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

        public async Task OpenMessage(LastMessage lastmessage)
        {
            if(lastmessage.User == OpenedUser)
            {
                MessageOpened = false;
                OpenedUser = new User();
            }
            else
            {
                MessageOpened = true;
                OpenedUser = lastmessage.User;
                if (!lastmessage.LastIsSeen && lastmessage.User != User)
                    await SetAsSeen(lastmessage);
            }
            DirectMessagesList.Clear();
            StateHasChanged();

            await GetDirectMessages();
        }

        public async Task OpenNewMessage()
        {
            // dohvatiti usera preko id-a
            var response = await Http.GetAsync($"api/users/{Id}");
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                List<User> users = await response.Content.ReadFromJsonAsync<List<User>>();
                OpenedUser = users.LastOrDefault();
                MessageOpened = true;
            }
        }

        public async Task SetAsSeen(LastMessage lastmessage)
        {
            var response = await Http.PostAsJsonAsync($"api/messages/setasseen", lastmessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                foreach(var message in AllMessagesList)
                {
                    if(message.MessageID == lastmessage.MessageID)
                    {
                        message.LastIsSeen = true;
                        message.UnreadMessages = 0;
                        break;
                    }
                }
            }
            StateHasChanged();
        }
    }
}
