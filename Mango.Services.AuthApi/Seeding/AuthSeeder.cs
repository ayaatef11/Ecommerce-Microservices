using Mango.Services.AuthApi.Data;
using Mango.Services.AuthApi.Models; // Ensure you have this using directive
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthApi.Seeding
{
    public class AuthSeeder(AuthContext _context, UserManager<ApplicationUser> _userManager)
    {
        

        public async Task SeedAsync()
        {
            // Check if any users already exist
            if (await _userManager.Users.AnyAsync())
            {
                return; 
            }

            var users = new List<ApplicationUser>
            {
                new ()
                {
                    UserName = "user1",
                    Email = "user1@example.com",
                },
                new ()
                {
                    UserName = "user2",
                    Email = "user2@example.com",
                }
            };

            foreach (var user in users)
            {
                await _userManager.CreateAsync(user, "Password123!");
            }

                await _context.SaveChangesAsync();
            }
        }
    }

