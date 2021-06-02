using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Goods
    {
        public Goods()
        {
            PartnersAndGoods = new HashSet<PartnersAndGoods>();
            InfluencersAndGoods = new HashSet<InfluencersAndGoods>();
            ShopsAndGoods = new HashSet<ShopsAndGoods>();
            OrdersAndGoods = new HashSet<OrdersAndGoods>();
            ProvidersAndGoods = new HashSet<ProvidersAndGoods>();
            EmployersAndGoods = new HashSet<EmployersAndGoods>();
        }
        public int GoodsId { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public int CategoriesId { get; set; }
        public string Info { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual ICollection<PartnersAndGoods> PartnersAndGoods { get; set; }
        public virtual ICollection<InfluencersAndGoods> InfluencersAndGoods { get; set; }
        public virtual ICollection<ShopsAndGoods> ShopsAndGoods { get; set; }
        public virtual ICollection<OrdersAndGoods> OrdersAndGoods { get; set; }
        public virtual ICollection<ProvidersAndGoods> ProvidersAndGoods { get; set; }
        public virtual ICollection<EmployersAndGoods> EmployersAndGoods { get; set; }
    }
}
