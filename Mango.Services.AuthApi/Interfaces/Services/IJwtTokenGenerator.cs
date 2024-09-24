using Mango.Services.AuthApi.Models;

namespace Mango.Services.AuthApi.Interfaces.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }
}
