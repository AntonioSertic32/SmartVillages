using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SmartVillages.Shared;
using SmartVillages.Shared.Marketplace;
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

        public bool Addedornot { get; set; }
        public string LinkToProfile { get; set; }
        public string LinkToMessages { get; set; }

        public List<int> Cart { get; set; } = new List<int>();

        protected override async Task OnParametersSetAsync()
        {
            var cart = await LocalStorage.GetItemAsync<List<int>>("cart");
            if(cart != null)
            {
                Cart = cart;
                Addedornot = Cart.Contains(Product.Id) ? true : false;
            }
            LinkToProfile = "/profile/" + Product.User.Id;
            LinkToMessages = "/messages/" + Product.User.Id;
        }

        public async Task AddToCart()
        {
            Cart.Add(Product.Id);
            Addedornot = !Addedornot;
            StateHasChanged();
            await LocalStorage.SetItemAsync("cart", Cart);
            await ChartCallback.InvokeAsync();
        }

        public async Task RemoveFromCart()
        {
            Cart.Remove(Product.Id);

            Addedornot = !Addedornot;
            StateHasChanged();
            await LocalStorage.SetItemAsync("cart", Cart);
            await ChartCallback.InvokeAsync();
        }

        public async Task Edit()
        {
        }

        public async Task Delete()
        {
        }
    }
}
