using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProvidersAndGoods
    {
        public int ProvidersAndGoodsId { get; set; }
        public int ProvidersId { get; set; }
        public int GoodsId { get; set; }

        public virtual Providers Providers { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
