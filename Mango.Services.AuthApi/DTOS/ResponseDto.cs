namespace Mango.Services.AuthApi.DTOS
{
    public class ResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
    }
}
