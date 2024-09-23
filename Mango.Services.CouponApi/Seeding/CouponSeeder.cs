using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Seeding
{
    public class CouponSeeder
    {
        private readonly CouponContext _context;

        public CouponSeeder(CouponContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Check if any coupons already exist
            if (!await _context.Coupones.AnyAsync())
            {
                // Seed initial data
                var coupons = new List<Coupon>
            {
              new Coupon
                {
                    Id = 20,
                    CouponCode = "ssd",
                    DiscountAmount = 6.6,
                    MinAmount = 80
                },
                 new Coupon{
                Id = 22,
                    CouponCode = "sdd",
                    DiscountAmount = 8.6,
                    MinAmount = 60
                }
            };

                await _context.Coupones.AddRangeAsync(coupons);
                await _context.SaveChangesAsync();
            }
        }
    }
}
