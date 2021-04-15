using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public string Password { get; set; }
        public string SecretCode { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
