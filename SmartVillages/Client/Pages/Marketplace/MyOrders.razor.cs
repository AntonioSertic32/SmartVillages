using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SmartVillages.Shared.MarketplaceModels;
using SmartVillages.Shared.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.Marketplace
{
    public class MyOrdersBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        public User User { get; set; }
        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();


        protected override async Task OnInitializedAsync()
        {

            User = await LocalStorage.GetItemAsync<User>("user");
            await GetMyOrders();
        }

        public async Task GetMyOrders()
        {
            var response = await Http.GetAsync($"api/orders/getmyorders/{User.Id}");
            List<OrderViewModel> returnValue = await response.Content.ReadFromJsonAsync<List<OrderViewModel>>();
            Orders = returnValue;
            StateHasChanged();
        }
    }
}
