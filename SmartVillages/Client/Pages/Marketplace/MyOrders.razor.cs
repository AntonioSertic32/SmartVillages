using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Client.Shared.Dialogs;
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
        [Inject] public IDialogService DialogService { get; set; }
        public User User { get; set; }
        public List<OrderViewModel> MyOrders { get; set; } = new List<OrderViewModel>();
        public List<CartItem> ActiveOrders { get; set; } = new List<CartItem>();
        public List<OrderViewModel> EndedOrders { get; set; } = new List<OrderViewModel>();
        public bool IsFarmer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<User>("user");
            IsFarmer = User.UserType.UserTypeId == 2 ? true : false;
            await GetMyOrders();
            await GetActiveOrders();
            await GetEndedOrders();
        }

        public async Task GetMyOrders()
        {
            var response = await Http.GetAsync($"api/orders/getmyorders/{User.Id}");
            List<OrderViewModel> returnValue = await response.Content.ReadFromJsonAsync<List<OrderViewModel>>();
            MyOrders = returnValue;
            StateHasChanged();
        }

        public async Task GetActiveOrders()
        {
            var response = await Http.GetAsync($"api/orders/getactiveorders/{User.Id}");
            List<CartItem> returnValue = await response.Content.ReadFromJsonAsync<List<CartItem>>();
            ActiveOrders = returnValue;
            StateHasChanged();
        }

        public async Task GetEndedOrders()
        {
            var response = await Http.GetAsync($"api/orders/getendedorders/{User.Id}");
            List<OrderViewModel> returnValue = await response.Content.ReadFromJsonAsync<List<OrderViewModel>>();
            EndedOrders = returnValue;
            StateHasChanged();
        }

        public void OpenDialog(OrderViewModel order)
        {
            var parameters = new DialogParameters();
            parameters.Add("Order", order);

            DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium };

            DialogService.Show<OpenMyOrdersMoreDetailsDialog>("Order review", parameters, maxWidth);
        }
    }
}
