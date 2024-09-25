using Mango.Services.ShoppingCartApi.Dtos;
using Mango.Services.ShoppingCartApi.Dtos.Products;
using Mango.Services.ShoppingCartApi.Interfaces.Services.Product;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartApi.Services.Products
{
    public class ProductService(IHttpClientFactory clientFactory) : IProductService
    {

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = clientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            }
            return new List<ProductDto>();
        }
    }
}
