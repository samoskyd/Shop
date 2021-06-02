using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Providers
    {
        public Providers()
        {
            ProvidersAndGoods = new HashSet<ProvidersAndGoods>();
        }
        public int ProvidersId { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ProvidersAndGoods> ProvidersAndGoods { get; set; }
    }
}
