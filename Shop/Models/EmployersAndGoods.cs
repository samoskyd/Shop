using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class EmployersAndGoods
    {
        public int EmployersAndGoodsId { get; set; }
        public int EmployersId { get; set; }
        public int GoodsId { get; set; }

        public virtual Employers Employers { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
