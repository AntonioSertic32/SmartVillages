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
        [Parameter] public bool IsForCustomerEnded { get; set; }
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

        // RATEING AND COMMENTING

        public string sampleText = "";

        public int selectedVal = 0;
        public int? activeVal;
        public void HandleHoveredValueChanged(int? val) => activeVal = val;
        public string LabelText => (activeVal ?? selectedVal) switch
        {
            1 => "Very bad",
            2 => "Bad",
            3 => "Sufficient",
            4 => "Good",
            5 => "Awesome!",
            _ => "Rate our product!"
        };

        public void RateAndComment(int id)
        {
            // dodat ocjenu u ocjene i onda azurirati produt sa ocjenom
            Console.WriteLine(id);
        }
    }
}
