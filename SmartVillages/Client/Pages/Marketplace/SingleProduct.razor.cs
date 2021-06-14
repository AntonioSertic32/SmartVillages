using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Client.Shared.Dialogs;
using SmartVillages.Shared;
using SmartVillages.Shared.MarketplaceModels;
using SmartVillages.Shared.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages
{
    public class SingleProductBase : ComponentBase
    {
        [Parameter] public Product Product { get; set; }
        [Parameter] public User User { get; set; }
        [Parameter] public EventCallback ChartCallback { get; set; }

        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] public IDialogService DialogService { get; set; }

        public bool Addedornot { get; set; }
        public string LinkToProfile { get; set; }
        public string LinkToMessages { get; set; }
        public List<CartItem> Cart { get; set; } = new List<CartItem>();

        protected override async Task OnParametersSetAsync()
        {
            var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart != null)
            {
                Cart = cart;
                Addedornot = Cart.Where(c => c.Product.Id == Product.Id).FirstOrDefault() != null ? true : false;
            }
            LinkToProfile = "/profile/" + Product.User.Id;
            LinkToMessages = "/messages/" + Product.User.Id;
        }

        public void Edit()
        {
        }

        public void Delete()
        {
        }

        public async Task RemoveFromCart()
        {
            var item = Cart.Where(c => c.Product.Id == Product.Id).FirstOrDefault();
            Cart.Remove(item);
            Addedornot = !Addedornot;
            StateHasChanged();
            await LocalStorage.SetItemAsync("cart", Cart);
            await ChartCallback.InvokeAsync();
        }

        public async void OpenAddToChartDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("Product", Product);
            parameters.Add("CartList", Cart);

            var dialog = DialogService.Show<AddToCartDialog>("Add to cart", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                Cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                await ChartCallback.InvokeAsync();
            }
        }
    }
}
