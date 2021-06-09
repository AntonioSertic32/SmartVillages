using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVillages.Shared.Marketplace
{
    public class Order
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public User Buyer { get; set; }
        public List<User> Sellers { get; set; }
        public float Price { get; set; }
        public int StatusCode { get; set; }

    }
}
