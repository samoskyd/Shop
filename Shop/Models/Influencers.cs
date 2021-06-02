using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Influencers
    {
        public Influencers()
        {
            InfluencersAndGoods = new HashSet<InfluencersAndGoods>();
        }
        public int InfluencersId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public DateTime? RegistrationDate { get; set; }
        
        public virtual ICollection<InfluencersAndGoods> InfluencersAndGoods { get; set; }
    }
}
