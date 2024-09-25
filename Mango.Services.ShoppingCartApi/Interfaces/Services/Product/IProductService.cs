using Mango.Services.ShoppingCartApi.Dtos.Products;

namespace Mango.Services.ShoppingCartApi.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
