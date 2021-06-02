using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class InfluencersAndGoods
    {
        public int InfluencersAndGoodsId { get; set; }
        public int InfluencersId { get; set; }
        public int GoodsId { get; set; }

        public virtual Influencers Influencers { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
