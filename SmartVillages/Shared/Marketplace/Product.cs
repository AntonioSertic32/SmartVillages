using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared.Marketplace
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string Image { get; set; }
        public bool Eco { get; set; }

    }
}
