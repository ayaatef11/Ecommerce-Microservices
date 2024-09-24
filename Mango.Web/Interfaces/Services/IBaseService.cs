using Mango.Web.DTOS;

namespace Mango.Web.Interfaces.Services
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
