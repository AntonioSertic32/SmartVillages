using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared.MarketplaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Shared.Dialogs
{
    public class AddToCartDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Product Product { get; set; }
        [Parameter] public List<CartItem> CartList { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        public void Cancel() => MudDialog.Cancel();
        public float Weight { get; set; }
        public float MaxValue { get; set; } = 0;
        public float fPrice { get; set; } = 0;
        public float FinalPrice { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            MaxValue = Convert.ToSingle(Product.Quantity);
            fPrice = Convert.ToSingle(Product.Price);
            await NewPrice();
        }

        public async Task AddToCart()
        {
            if (CartList == null)
            {
                CartList = new List<CartItem>();
            }
            Product NewProduct = Product;
            NewProduct.ProductImage = null;
            NewProduct.User.UserImage = null;
            CartItem item = new CartItem { Product = NewProduct, Quantity = Weight, Price = FinalPrice, StatusCode = 1 };
            CartList.Add(item);
            await LocalStorage.SetItemAsync("cart", CartList);
            MudDialog.Close(DialogResult.Ok(true));
        }

        public async Task NewPrice()
        {
            FinalPrice = Weight * fPrice;
            StateHasChanged();
        }
    }
}
