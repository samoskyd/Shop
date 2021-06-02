using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class ShopContext
    {
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employers> Employers { get; set; }
        public virtual DbSet<EmployersAndGoods> EmployersAndGoods { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Influencers> Influencers { get; set; }
        public virtual DbSet<InfluencersAndGoods> InfluencersAndGoods { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersAndGoods> OrdersAndGoods { get; set; }
        public virtual DbSet<PartnersAndGoods> PartnersAndGoods { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<ProvidersAndGoods> ProvidersAndGoods { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<ShopsAndGoods> ShopsAndGoods { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
