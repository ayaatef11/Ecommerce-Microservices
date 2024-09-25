using Mango.Web.DTOS.Products;

namespace Mango.Web.DTOS.Order
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }=string.Empty;
        public double Price { get; set; }
    }
}
