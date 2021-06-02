using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Shops
    {
        public Shops()
        {
            ShopsAndGoods = new HashSet<ShopsAndGoods>();
        }
        public int ShopsId { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }

        public virtual ICollection<ShopsAndGoods> ShopsAndGoods { get; set; }
    }
}
