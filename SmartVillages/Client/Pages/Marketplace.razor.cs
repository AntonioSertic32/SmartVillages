using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartVillages.Client.Shared.Dialogs;
using SmartVillages.Shared;
using SmartVillages.Shared.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages
{
    public class MarketplaceBase : ComponentBase
    {
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public HttpClient Http { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        public string Search { get; set; }
        public bool opened { get; set; }
        public User User { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<User>("user");

            await GetLastProducts();
        }

        public async Task OpenCloseItem()
        {
            opened = !opened;
        }

        public async Task GetLastProducts()
        {
            var response = await Http.GetAsync($"api/productcategories/");
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                ProductCategories = await response.Content.ReadFromJsonAsync<List<ProductCategory>>();
                StateHasChanged();
            }
        }

        public void OpenDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Are you sure you want to remove thisguy@emailz.com from this account?");

            DialogService.Show<AddNewProductDialog>("Add New Product", parameters);
        }
    }
}
