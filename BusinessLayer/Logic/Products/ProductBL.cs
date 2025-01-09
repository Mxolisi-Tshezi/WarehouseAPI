using BusinessLayer.Functions;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataLayer.DatabaseContext;

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
            using (var context = new WarehouseContext(WarehouseContext.ops.dbOptions))
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Save the product
                    context.Products.Add(product);
                    await context.SaveChangesAsync();

                    // Initialize stock for the product in all existing warehouses
                    var warehouses = context.Warehouses.ToList();
                    foreach (var warehouse in warehouses)
                    {
                        context.WarehouseProducts.Add(new WarehouseProduct
                        {
                            WarehouseCode = warehouse.Code,
                            ProductCode = product.Code,
                            QuantityOnHand = 0
                        });
                    }

                    await context.SaveChangesAsync();

                    // Commit transaction
                    await transaction.CommitAsync();

                    return product;
                }
                catch (Exception)
                {
                    // Rollback transaction on failure
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public static async Task<Product> GetByID(Guid ProductID)
        {
            return DBAccess<Product>.GetQueryable().Where(x => x.Code == ProductID).FirstOrDefault();
        }
    }
}
