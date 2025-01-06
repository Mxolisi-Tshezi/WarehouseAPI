using BusinessLayer.Functions;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace BusinessLayer.Logic.Products
{
    public class ProductBL
    {

        public static async Task<Product> Update(Product product)
        {
            return await DBAccess<Product>.Update(product);
        }

        public static async Task<Product> Save(Product product)
        {
            return await DBAccess<Product>.Save(product);
        }

        public static async Task<Product> GetByID(Guid ProductID)
        {
            return DBAccess<Product>.GetQueryable().Where(x => x.Code == ProductID).FirstOrDefault();
        }

    }
}
