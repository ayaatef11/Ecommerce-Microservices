using Mango.Services.AuthApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthApi.Data
{
    public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);//this creates the defautl primary key
        }
    }
}
