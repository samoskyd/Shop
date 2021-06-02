using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Employers
    {
        public Employers()
        {
            EmployersAndGoods = new HashSet<EmployersAndGoods>();
        }
        public int EmployersId { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }

        public virtual ICollection<EmployersAndGoods> EmployersAndGoods { get; set; }
    }
}
