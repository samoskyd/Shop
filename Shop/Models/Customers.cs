using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public int CustomersId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DeliveryAdress { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
