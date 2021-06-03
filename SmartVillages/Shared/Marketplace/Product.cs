using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared.Marketplace
{
    public class Product
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite naziv proizvoda")]
        public string Title { get; set; }
        [Required, Range(1.0, Double.MaxValue, ErrorMessage = "Cijena mora biti veća od 0")]
        public double Price { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite opis proizvoda")]
        public string Description { get; set; }
        public User User { get; set; }
        public ProductCategory ProductCategory { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite sliku proizvoda")]
        public string Image { get; set; }
        public bool Eco { get; set; }
        [Required, Range(1.0, Double.MaxValue, ErrorMessage = "Količina mora biti veća od 0")]
        public double Quantity { get; set; }

    }
}
