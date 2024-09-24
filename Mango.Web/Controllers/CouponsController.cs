using Mango.Web.DTOS;
using Mango.Web.Interfaces.Services;
using Mango.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    //TempData in ASP.NET Core MVC is used to store data that needs to persist between two consecutive requests, typically for redirection scenarios. It provides a short-lived way to pass information from one request to another.
    public class CouponsController(ICouponService couponService) : Controller
    {
        public async Task< IActionResult> Index()
		{
			List<CouponDto>? list = new();

			ResponseDto? response = await couponService.GetAllCouponsAsync();

            //if (response != null && response.IsSuccess)

            //list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            if (response == null || response.IsSuccess == false) TempData["error"] = response?.Message;
            else TempData["success"] = response?.Message;
			return View(response.Result);
		}
		public async Task< IActionResult> CouponCreate(CouponDto cc)/*Validating the model ensures that the data submitted by the client is accurate, complete, and follows the validation rules you've defined. This can include checking for:
Required fields
Data format (e.g., email format, string length)
Value ranges (e.g., a number should be greater than 0)
Type safety (e.g., string vs. integer*/
        {
			if (ModelState.IsValid)
			{
				ResponseDto response = await couponService.CreateCouponsAsync(cc);
				if(response !=null &&response.IsSuccess)return RedirectToAction(nameof(Index));
			}
			return View(cc);
		}
       /* public async Task<IActionResult> CouponCreate()
        {
            return View();
        }*/
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                //CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(response.Result);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await couponService.DeleteCouponsAsync(couponDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(couponDto);
        }

    }
    //we check the model state in the http methods: post , put , patch , delete 
}

