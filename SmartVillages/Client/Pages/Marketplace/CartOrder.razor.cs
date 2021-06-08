using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.Marketplace
{
    public partial class CartOrder
    {
        [Inject] ILocalStorageService LocalStorage { get; set; }
        public float Weight { get; set; }

        public MudTabs tabs;
        public MudTabPanel panel01;
        public MudTabPanel panel02;
        public MudTabPanel panel03;
        public List<CartItem> Cart { get; set; } = new List<CartItem>();

        protected override async Task OnInitializedAsync()
        {
            Cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
        }

        public void Activate(int index)
        {
            tabs.ActivatePanel(index);
        }

        public void Activate(MudTabPanel panel)
        {
            tabs.ActivatePanel(panel);
        }

        public void Activate(object id)
        {
            tabs.ActivatePanel(id);
        }

        public async Task NewPrice(int id)
        {
            CartItem Item = Cart.Where(c => c.ProductId == id).FirstOrDefault();
            Item.FinalPrice = Item.ProductQuantity * Item.PriceOfOne;
            LocalStorage.SetItemAsync("cart", Cart);
        }

    }
}
