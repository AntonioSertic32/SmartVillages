using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MoreLinq;
using MudBlazor;
using SmartVillages.Shared;
using SmartVillages.Shared.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Shared.Dialogs
{
    public class AddNewProductDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public User User { get; set; }
        [Parameter] public List<ProductCategory> AllCategories { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }

        public string NewProduct_Title { get; set; }
        public double? NewProduct_Price { get; set; }
        public string NewProduct_Description { get; set; }
        public bool NewProduct_Eco { get; set; }
        public string NewProduct_Image { get; set; } = "";

        public List<string> Categories { get; set; } = new List<string>();
        public List<string> SubCategoriesOne { get; set; } = new List<string>();
        public List<string> SubCategoriesTwo { get; set; } = new List<string>();
        public List<string> Species { get; set; } = new List<string>();

        public string Category { get; set; }
        public string SubCategoryOne { get; set; }
        public string SubCategoryTwo { get; set; }
        public string Specie { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Categories = AllCategories.DistinctBy(x => x.Name).Select(s => s.Name).ToList();
            StateHasChanged();
        }

        public async Task Sort(int id)
        {
            if(id == 1)
            {
                SubCategoriesOne.Clear();
                SubCategoryOne = "";
                SubCategoriesTwo.Clear();
                SubCategoryTwo = "";
                Species.Clear();
                Specie = "";
                foreach (var i in AllCategories.Where(x => x.Name == Category).DistinctBy(d => d.SubCategoryOne))
                {
                    SubCategoriesOne.Add(i.SubCategoryOne);
                }            
            }
            if(id == 2)
            {
                SubCategoriesTwo.Clear();
                SubCategoryTwo = "";
                Species.Clear();
                Specie = "";
                foreach (var i in AllCategories.Where(x => x.SubCategoryOne == SubCategoryOne).DistinctBy(d => d.SubCategoryTwo))
                {
                    SubCategoriesTwo.Add(i.SubCategoryTwo);
                }
            }
            if (id == 3)
            {
                Species.Clear();
                Specie = "";
                foreach (var i in AllCategories.Where(x => x.SubCategoryTwo == SubCategoryTwo).DistinctBy(d => d.Species))
                {
                    Species.Add(i.Species);
                }
            }
        }

        public void Submit() => MudDialog.Close(DialogResult.Ok(true));
        public void Cancel() => MudDialog.Cancel();

        public async Task UploadFiles(InputFileChangeEventArgs e)
        {
            var entries = e.GetMultipleFiles();
            //validations
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add($"Files with {entries.FirstOrDefault().Size} bytes size are not allowed", Severity.Error);
            Snackbar.Add($"Files starting with letter {entries.FirstOrDefault().Name.Substring(0, 1)} are not recommended", Severity.Warning);
            Snackbar.Add($"This file has the extension {entries.FirstOrDefault().Name.Split(".").Last()}", Severity.Info);

            //get the file
            var file = e.File;
            //read that file in a byte array
            var buffer = new byte[file.Size];
            await file.OpenReadStream(1512000).ReadAsync(buffer);
            //convert byte array to base 64 string
            NewProduct_Image = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
            StateHasChanged();
        }
    }
}
