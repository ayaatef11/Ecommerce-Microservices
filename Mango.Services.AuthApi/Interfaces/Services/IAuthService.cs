using Mango.Services.AuthApi.DTOS;

namespace Mango.Services.AuthApi.Interfaces.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
