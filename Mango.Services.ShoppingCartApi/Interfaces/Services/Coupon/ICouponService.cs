namespace Mango.Services.ShoppingCartApi.Interfaces.Services.Coupon
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
