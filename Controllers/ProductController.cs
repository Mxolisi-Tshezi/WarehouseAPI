using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Services.Warehouses;

namespace WarehouseAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("Save Warehouse")]
        public async Task<ActionResult> SaveWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var warehouseEntity = await _productService.Save(warehouse);

                // if company is null return bad request
                if (warehouseEntity is null) return BadRequest();

                if (warehouseEntity.Code != null) return Ok();
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost]
        [Route("Update Warehouse")]
        public async Task<ActionResult> UpdateWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var warehouseEntity = await _productService.Update(warehouse);

                // if company is null return bad request
                if (warehouseEntity is null) return BadRequest();

                if (warehouseEntity.Code != null) return Ok();
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet]
        [Route("GetWarehousesById")]
        public async Task<IActionResult> GetCompaniesByTypeName(Guid Id)
        {
            try
            {
                var warehouses = await _productService.GetByID(Id);
                if (warehouses!=null)
                {
                    return Ok(warehouses);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
