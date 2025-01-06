using BusinessLayer.Logic.Products;
using BusinessLayer.Logic.Warehouses;
using DataLayer.Models;

namespace WarehouseAPI.Services.Products
{
    public class ProductService: IProductService
    {

        public async Task<Product> Save(Product product)
        {
            return await ProductBL.Save(product);
        }
        public async Task<Product> Update(Product product)
        {
            return await ProductBL.Update(product);
        }
        public Task<Product> GetByID(Guid productId)
        {
            return ProductBL.GetByID(productId);
        }
    }
}
