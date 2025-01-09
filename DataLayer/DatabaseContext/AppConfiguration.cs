using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace DataLayer.DatabaseContext
{
    public class AppConfiguration
    {

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path); // Not optional, has to be there
            var root = configBuilder.Build();
            var appsettings = root.GetSection("ConnectionStrings:WarehouseConnection"); // Change to your MySQL connection string key
            SqlServerConnectionString = appsettings.Value;
        }
        public string SqlServerConnectionString { get; set; }
    }
}