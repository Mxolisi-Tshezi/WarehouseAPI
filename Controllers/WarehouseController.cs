using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WarehouseAPI.Services.Warehouses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataLayer.Models;


namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService) {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        [Route("Save Warehouse")]
        public async Task<ActionResult> SaveWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var warehouseEntity = await _warehouseService.Save(warehouse);

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
                var warehouseEntity = await _warehouseService.Update(warehouse);

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
                var warehouses = await _warehouseService.GetByID(Id);
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
