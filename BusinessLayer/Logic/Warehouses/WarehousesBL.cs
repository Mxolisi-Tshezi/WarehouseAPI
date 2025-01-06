using BusinessLayer.Functions;
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

        public static async Task<Warehouse> Save(Warehouse Warehouse)
        {
            return await DBAccess<Warehouse>.Save(Warehouse);
        }

        public static async Task<Warehouse> GetByID(Guid WarehouseID)
        {
            return DBAccess<Warehouse>.GetQueryable().Where(x => x.Code == WarehouseID).FirstOrDefault();
        }

    }
}
