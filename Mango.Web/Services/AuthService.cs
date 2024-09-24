using Mango.Web.DTOS;
using Mango.Web.DTOS.Auth;
using Mango.Web.Interfaces.Services;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    public class AuthService(IBaseService baseService) : IAuthService
    {
        public async Task<ResponseDto?> AssignRoleAsync(RegisterDto registrationRequestDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthAPIBase + "/api/Auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/Auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterDto registrationRequestDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthAPIBase + "/api/Auth/register"
            }, withBearer: false);
        }
    }
}