using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Orders
    {
        public Orders()
        {
            OrdersAndGoods = new HashSet<OrdersAndGoods>();
        }
        public int OrdersId { get; set; }
        public DateTime? Date { get; set; }
        public bool PaymentStatus { get; set; }
        public bool DeliveryStatus { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual ICollection<OrdersAndGoods> OrdersAndGoods { get; set; }
    }
}
