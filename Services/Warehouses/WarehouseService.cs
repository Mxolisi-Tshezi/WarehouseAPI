using BusinessLayer.Logic.Warehouses;
using DataLayer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WarehouseAPI.Services.Warehouses
{
    public class WarehouseService : IWarehouseService
    {
        public async Task<Warehouse> Save(Warehouse warehouse)
        {
            return await WarehousesBL.Save(warehouse);
        }
        public async Task<Warehouse> Update(Warehouse warehouse)
        {
            return await WarehousesBL.Update(warehouse);
        }
        public Task<Warehouse> GetByID(Guid warehouseId)
        {
            return WarehousesBL.GetByID(warehouseId);
        }
    }
}