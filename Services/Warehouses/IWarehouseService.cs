using DataLayer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WarehouseAPI.Services.Warehouses
{
    public interface IWarehouseService
    {
        Task<Warehouse> Save(Warehouse warehouse);
        Task<Warehouse> Update(Warehouse warehouse);
        Task<Warehouse> GetByID(Guid warehouseId);

    }
}
