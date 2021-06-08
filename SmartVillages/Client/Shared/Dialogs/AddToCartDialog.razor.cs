using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Shared.Dialogs
{
    public class AddToCartDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public int ProductId { get; set; }
        [Parameter] public List<CartItem> CartList { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        public void Cancel() => MudDialog.Cancel();
        public float Weight { get; set; }


        public async Task AddToCart()
        {
            if (CartList == null)
            {
                CartList = new List<CartItem>();
            }
            CartItem item = new CartItem { ProductId = ProductId, ProductWeight = Weight };
            CartList.Add(item);
            await LocalStorage.SetItemAsync("cart", CartList);
            MudDialog.Close(DialogResult.Ok(true));
        }
    }
}
