using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared
{
    public class User
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite ime")]
        [StringLength(20, ErrorMessage = "Ime mora biti manje od 20 znakova")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite prezime")]
        [StringLength(20, ErrorMessage = "Prezime mora biti manje od 20 znakova")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite email"), EmailAddress]
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Sex { get; set; }
        public string OIB { get; set; }
        public bool EmailConfirm { get; set; } = false;
        public bool Locked { get; set; } = true;
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo unesite lozinku")]
        [StringLength(30, ErrorMessage = "Potrebno je unijeti barem 8 znakova", MinimumLength = 8)]
        public string Password { get; set; }
        public string SecretCode { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
