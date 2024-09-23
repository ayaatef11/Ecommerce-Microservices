using Mango.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace Mango.Services.CouponApi.Data
{
    public class CouponContext:DbContext
    {
        /*The DbContextOptions parameter is used to configure the context, including things like the database provider (e.g., SQL Server, SQLite) and the connection string.
This allows for configuration through Dependency Injection (DI) in ASP.NET Core, which is essential for setting up the context properly when the application starts.*/
        public CouponContext(DbContextOptions<CouponContext> options) :base(options)
        {
            
        }
        public DbSet<Coupon> Coupones { get; set; }//it is abstract you can't create an instance of it 
        //configure the database provider 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //fluent api configuration 
            base.OnConfiguring(optionsBuilder);
            
        }
        // this function is for mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().Property(x => x.DiscountAmount).HasColumnType("Decimal(5,2)");
            base.OnModelCreating(modelBuilder);
        }
    }
}
