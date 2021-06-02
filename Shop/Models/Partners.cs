using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Partners
    {
        public Partners()
        {
            PartnersAndGoods = new HashSet<PartnersAndGoods>();
        }
        public int PartnersId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Info { get; set; }

        public virtual ICollection<PartnersAndGoods> PartnersAndGoods { get; set; }
    }
}
