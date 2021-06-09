using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared.Marketplace
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public float ProductQuantity { get; set; }
        public float MaxQuantity { get; set; }
        public float FinalPrice { get; set; }
        public float PriceOfOne { get; set; }

    }
}
