using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DatabaseContext
{
    public class WarehouseContext : DbContext
    {

        public class OptionsBuild
        {
            public OptionsBuild()
            {
                appConfiguration = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
                opsBuilder.UseSqlServer(appConfiguration.SqlServerConnectionString); // Use SQL Server
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<WarehouseContext> opsBuilder { get; set; }
            public DbContextOptions<WarehouseContext> dbOptions { get; set; }
            private AppConfiguration appConfiguration { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
    }

}