
using Mango.Web.DTOS;
using Mango.Web.DTOS.Auth;

namespace Mango.Web.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ResponseDto?> RegisterAsync(RegisterDto registrationRequestDto);
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegisterDto rr);
    }
}
