using DataLayer.Models;

namespace WarehouseAPI.Services.Products
{
    public interface IProductService
    {

        Task<Product> Save(Product product);
        Task<Product> Update(Product Product);
        Task<Product> GetByID(Guid productId);
    }
}