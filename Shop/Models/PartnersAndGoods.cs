using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class PartnersAndGoods
    {
        public int PartnersAndGoodsId { get; set; }
        public int PartnersId { get; set; }
        public int GoodsId { get; set; }

        public virtual Partners Partners { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
