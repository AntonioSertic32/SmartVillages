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
        public bool Opened { get; set; }
        public User User { get; set; } = new User();
        public bool OnlyForFarmer { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public List<Product> Products { get; set; } = new List<Product>();
        public bool CanOpenDialog { get; set; }
        public Product OpenedProduct { get; set; }
        public List<int> Cart { get; set; } = new List<int>();

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<User>("user");
            OnlyForFarmer = User.UserType.UserTypeId == 2 ? true : false;
            await GetProducts();
            Cart = await LocalStorage.GetItemAsync<List<int>>("cart");
            StateHasChanged();
        }

        public async Task OpenCloseItem(int id = 0)
        {
            if (id != 0)
            {
                if (!Opened)
                {
                    foreach (var p in Products)
                    {
                        if(p.Id == id)
                        {
                            OpenedProduct = p;
                            break;
                        }
                    }
                }
            }
            Opened = !Opened;
            StateHasChanged();
        }

        public async Task GetCategories()
        {
            var response = await Http.GetAsync($"api/productcategories/");
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                ProductCategories = await response.Content.ReadFromJsonAsync<List<ProductCategory>>();
                CanOpenDialog = true;
                StateHasChanged();
            }
        }

        public async Task GetProducts()
        {
            var response = await Http.GetAsync($"api/products/getlastten/");
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                Products = await response.Content.ReadFromJsonAsync<List<Product>>();
                StateHasChanged();
            }
            await GetCategories();
        }

        public async Task OpenDialog()
        {
            if (CanOpenDialog)
            {
                var parameters = new DialogParameters();
                parameters.Add("User", User);
                parameters.Add("AllCategories", ProductCategories);

                var dialog = DialogService.Show<AddNewProductDialog>("Add New Product", parameters);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    Console.WriteLine("Evo mee");
                }

            }
        }

        public async Task UpdateOnCart()
        {
            Cart = await LocalStorage.GetItemAsync<List<int>>("cart");
            StateHasChanged();
        }
    }
}
