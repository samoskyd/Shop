using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopsAndGoods
    {
        public int ShopsAndGoodsId { get; set; }
        public int ShopsId { get; set; }
        public int GoodsId { get; set; }

        public virtual Shops Shops { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
