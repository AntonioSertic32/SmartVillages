using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Shared.MarketplaceModels;
using SmartVillages.Shared.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartVillages.Client.Shared.Dialogs
{
    public class OpenActiveEndedMoreDetailsDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public OrderViewModel Order { get; set; }
        [Parameter] public User User { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }
        public float MyPrice { get; set; } = 0;
        public bool Ordered { get; set; }

        protected override Task OnInitializedAsync()
        {
            MyPrice = 0;
            foreach (var item in Order.CartItems)
            {
                if (item.Product.User.Id == User.Id)
                {
                    MyPrice += item.Price;
                }
                if (item.StatusCode > 1)
                {
                    Ordered = true;
                }
            }
            return base.OnInitializedAsync();
        }

        public void Cancel() => MudDialog.Cancel();

        public async Task Submit()
        {
            await Http.PostAsJsonAsync($"api/orders/setasordered/{User.Id}", Order);

            MudDialog.Close(DialogResult.Ok(true));
        }
    }
}
