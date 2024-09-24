namespace Mango.Services.CouponApi.DTOS
{
    public class ResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public List<CouponDto>? Result { get; set; }
    }
}
