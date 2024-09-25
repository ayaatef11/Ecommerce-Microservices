using Mango.Services.ShoppingCartApi.Dtos.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartApi.Models
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }=new();
        public int ProductId { get; set; }
        [NotMapped]//not mapped to the database
        public ProductDto Product { get; set; } = new();
        public int Count { get; set; }//count for products
    }
}
