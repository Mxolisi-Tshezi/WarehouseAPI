using DataLayer.DatabaseContext;
using DataLayer.Models;

namespace BusinessLayer.Logic.Orders
{
    public class OrderBL
    {
        private readonly WarehouseContext _context;

        public OrderBL(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            // Validate source and destination warehouse quantities
            var sourceStock = _context.WarehouseProducts
                .FirstOrDefault(wp => wp.WarehouseCode == order.SourceWarehouseCode && wp.ProductCode == order.ProductCode);

            if (sourceStock == null || sourceStock.QuantityOnHand < order.Quantity)
                throw new InvalidOperationException("Insufficient stock in source warehouse");

            // Adjust quantities
            sourceStock.QuantityOnHand -= order.Quantity;

            var destinationStock = _context.WarehouseProducts
                .FirstOrDefault(wp => wp.WarehouseCode == order.DestinationWarehouseCode && wp.ProductCode == order.ProductCode);

            if (destinationStock == null)
            {
                destinationStock = new WarehouseProduct
                {
                    WarehouseCode = order.DestinationWarehouseCode,
                    ProductCode = order.ProductCode,
                    QuantityOnHand = 0
                };
                _context.WarehouseProducts.Add(destinationStock);
            }

            destinationStock.QuantityOnHand += order.Quantity;

            // Save the order
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public IEnumerable<WarehouseProduct> GetProductStock(Guid? productCode = null, Guid? warehouseCode = null)
        {
            var query = _context.WarehouseProducts.AsQueryable();

            if (productCode != null)
                query = query.Where(wp => wp.ProductCode == productCode);

            if (warehouseCode != null)
                query = query.Where(wp => wp.WarehouseCode == warehouseCode);

            return query.ToList();
        }
    }
}
