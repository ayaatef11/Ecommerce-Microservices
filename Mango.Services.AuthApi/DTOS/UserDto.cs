namespace Mango.Services.AuthApi.DTOS
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
