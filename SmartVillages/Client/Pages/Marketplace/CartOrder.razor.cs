using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared;
using SmartVillages.Shared.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.Marketplace
{
    public class CartOrderBase : ComponentBase
    {
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Parameter] public EventCallback CartUpdate { get; set; }
        public float Weight { get; set; }
        public float FinalCartPrice { get; set; }
        public MudTabs tabs { get; set; }
        public int Count { get; set; } = 0;
        public List<CartItem> Cart { get; set; } = new List<CartItem>();
        public User User { get; set; }
        public DateTime? date { get; set; } = DateTime.Today.AddDays(1);
        public string sampleText { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        protected override async Task OnParametersSetAsync()
        {
            Cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
            User = await LocalStorage.GetItemAsync<User>("user");
            FinalCartPrice = Cart.Select(s => s.FinalPrice).Sum();
        }

        public async Task Reset()
        {
            Count = 0;
        }

        public void Activate(int index)
        {
            Reset();
            tabs.ActivatePanel(index);
        }

        public async Task NewPrice(int id)
        {
            Count++;
            if(Count > Cart.Count())
            {
                CartItem Item = Cart.Where(c => c.ProductId == id).FirstOrDefault();
                Item.FinalPrice = Item.ProductQuantity * Item.PriceOfOne;
                FinalCartPrice = Cart.Select(s => s.FinalPrice).Sum();
                await LocalStorage.SetItemAsync("cart", Cart);
                await CartUpdate.InvokeAsync();
            }
        }

        public async Task RemoveFromCart(CartItem item)
        {
            Cart.Remove(item);
            await LocalStorage.SetItemAsync("cart", Cart);
            await CartUpdate.InvokeAsync();
        }

    }
}
