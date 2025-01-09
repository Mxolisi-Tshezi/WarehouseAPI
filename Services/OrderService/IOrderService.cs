using DataLayer.Models;

namespace WarehouseAPI.Services.Orders
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        IEnumerable<WarehouseProduct> GetProductStock(Guid? productCode = null, Guid? warehouseCode = null);
    }
}
