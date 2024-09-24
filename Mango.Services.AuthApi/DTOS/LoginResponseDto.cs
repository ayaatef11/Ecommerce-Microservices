namespace Mango.Services.AuthApi.DTOS
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }= new UserDto();
        public string Token { get; set; } = string.Empty;
    }
}
