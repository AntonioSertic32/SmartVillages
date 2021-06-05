using Microsoft.AspNetCore.Components;
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

        public bool Addedornot { get; set; }

        public async Task Add()
        {
            Addedornot = !Addedornot;
        }
    }
}
