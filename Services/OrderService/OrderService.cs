using BusinessLayer.Logic.Orders;
using DataLayer.Models;

namespace WarehouseAPI.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly OrderBL _orderBL;

        public OrderService(OrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderBL.CreateOrder(order);
        }

        public IEnumerable<WarehouseProduct> GetProductStock(Guid? productCode = null, Guid? warehouseCode = null)
        {
            return _orderBL.GetProductStock(productCode, warehouseCode);
        }
    }
}
