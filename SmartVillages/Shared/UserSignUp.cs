using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared
{
    public class UserSignUp
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite ime")]
        [StringLength(20, ErrorMessage = "Ime mora biti manje od 20 znakova")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite prezime")]
        [StringLength(20, ErrorMessage = "Prezime mora biti manje od 20 znakova")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite email"), EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite oib")]
        public string OIB { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite zemlju")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite grad")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite adresu")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite broj mobitela")]
        public string Number { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite lozinku")]
        [StringLength(30, ErrorMessage = "Potrebno je unijeti barem 8 znakova", MinimumLength = 8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju")]
        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite datum rođenja")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Molimo odaberite tip")]
        public int UserType { get; set; }
    }
}
