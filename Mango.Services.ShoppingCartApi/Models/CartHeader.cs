using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartApi.Models
{
    public class CartHeader
    {
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }

        [NotMapped]//why
        public double Discount { get; set; }
        [NotMapped]//why also 
        public double CartTotal { get; set; }
    }
}
