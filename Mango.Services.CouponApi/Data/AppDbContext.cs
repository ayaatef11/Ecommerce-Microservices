using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace Mango.Services.CouponApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        /*The DbContextOptions parameter is used to configure the context, including things like the database provider (e.g., SQL Server, SQLite) and the connection string.
This allows for configuration through Dependency Injection (DI) in ASP.NET Core, which is essential for setting up the context properly when the application starts.*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext > options) :base(options)
        {
            
        }
    }
}
