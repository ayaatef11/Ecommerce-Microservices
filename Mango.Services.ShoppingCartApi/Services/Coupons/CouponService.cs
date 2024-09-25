using Mango.Services.ShoppingCartApi.Dtos;
using Mango.Services.ShoppingCartApi.Dtos.Coupons;
using Mango.Services.ShoppingCartApi.Interfaces.Services.Coupon;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartApi.Services.Coupons
{
    public class CouponService(IHttpClientFactory clientFactory):ICouponService
    {

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = clientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");//provide it 
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}
