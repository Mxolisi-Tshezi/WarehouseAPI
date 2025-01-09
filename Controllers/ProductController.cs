using BusinessLayer.Logic.Products;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Services.Products;
using WarehouseAPI.Services.Warehouses;

namespace WarehouseAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("Save Product")]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var productEntity = await _productService.Save(product);

                // if company is null return bad request
                if (productEntity is null) return BadRequest();

                if (productEntity.Code != null) return Ok();
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost]
        [Route("Update Product")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var productEntity = await _productService.Update(product);

                // if company is null return bad request
                if (productEntity is null) return BadRequest();

                if (productEntity.Code != null) return Ok();
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<IActionResult> GetCompaniesByTypeName(Guid Id)
        {
            try
            {
                var products = await _productService.GetByID(Id);
                if (products!=null)
                {
                    return Ok(products);
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