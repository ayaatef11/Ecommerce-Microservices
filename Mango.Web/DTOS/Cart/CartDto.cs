namespace Mango.Web.DTOS.Cart
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; } = new();
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
