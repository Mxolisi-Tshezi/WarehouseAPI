using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Services.Orders;
using DataLayer.Models;

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            try
            {
                var createdOrder = await _orderService.CreateOrder(order);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductStock")]
        public ActionResult GetProductStock([FromQuery] Guid? productCode, [FromQuery] Guid? warehouseCode)
        {
            var stock = _orderService.GetProductStock(productCode, warehouseCode);
            return Ok(stock);
        }
    }
}
