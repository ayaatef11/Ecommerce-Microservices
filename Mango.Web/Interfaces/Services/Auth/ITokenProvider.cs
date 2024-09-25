namespace Mango.Web.Interfaces.Services.Auth
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
