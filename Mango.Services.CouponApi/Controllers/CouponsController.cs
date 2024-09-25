using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.DTOS;
using Mango.Services.CouponApi.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponsController(CouponContext cop) : ControllerBase
    {
        //crud operations
        [HttpGet]
        public List<CouponDto> GetCoupons()
        {
            var coupons = cop.Coupones.ToList();

            // Use Mapster to map the Coupon entities to CouponDto
            List<CouponDto> couponsDtos = coupons.Adapt<List<CouponDto>>();
            return couponsDtos;
        }
        [HttpGet("{Id:int}")]
        //[Route]
        public CouponDto GetCouponById(int Id)
        {
            var coupon=cop.Coupones.FirstOrDefault(x => x.Id == Id);
            return coupon.Adapt<CouponDto>();
        }

        [HttpPost]
       // [Authorize(Roles ="ADMIN")]
        public ActionResult< CouponDto> Post([FromBody]CouponDto coupon)
        {
            var coupone=coupon.Adapt<Coupon>();//means turn it to coupon
            cop.Coupones.Add(coupone);
            cop.SaveChanges();
            return CreatedAtAction(nameof(GetCouponById), new { Id = coupon.Id }, coupon.Adapt<CouponDto>());

        }

        [HttpPut]
        public ActionResult< CouponDto> Put([FromBody] CouponDto coupon)//we add the id in the parameters for the put method ,,find the existing coupon then updating here but that way of reversing the mapping don't need that
        {
            var coupone = coupon.Adapt<Coupon>();//means turn it to coupon
            cop.Coupones.Update(coupone);
            cop.SaveChanges();
            return CreatedAtAction(nameof(GetCouponById), new {id=coupon.Id}, coupon.Adapt<CouponDto>());
        }
        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            var coupon = cop.Coupones.FirstOrDefault(x => x.Id == id);
            cop.Coupones.Remove(coupon);
            cop.SaveChanges();
            return NoContent();
        }
    }

    }

