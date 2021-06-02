using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Categories
    {
        public Categories()
        {
            Goods = new HashSet<Goods>();
        }
        public int CategoriesId { get; set; }
        public string FullName { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Goods> Goods { get; set; }
    }
}
