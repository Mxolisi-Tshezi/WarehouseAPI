using BusinessLayer.Functions;
using DataLayer.DatabaseContext;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessLayer.Logic.Warehouses
{
    public class WarehousesBL
    {
        public static async Task<Warehouse> Update(Warehouse warehouse)
        {
            return await DBAccess<Warehouse>.Update(warehouse);
        }

        public static async Task<Warehouse> Save(Warehouse warehouse)
        {
            using (var context = new WarehouseContext(WarehouseContext.ops.dbOptions))
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Save the warehouse
                    context.Warehouses.Add(warehouse);
                    await context.SaveChangesAsync();

                    // Initialize stock for all existing products in the new warehouse
                    var products = context.Products.ToList();
                    foreach (var product in products)
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

                    return warehouse;
                }
                catch (Exception)
                {
                    // Rollback transaction on failure
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public static async Task<Warehouse> GetByID(Guid WarehouseID)
        {
            return DBAccess<Warehouse>.GetQueryable().Where(x => x.Code == WarehouseID).FirstOrDefault();
        }
    }
}
