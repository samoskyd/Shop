using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrdersAndGoods
    {
        public int OrdersAndGoodsId { get; set; }
        public int OrdersId { get; set; }
        public int GoodsId { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
