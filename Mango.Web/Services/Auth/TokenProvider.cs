﻿using Mango.Web.Interfaces.Services.Auth;
using Mango.Web.Utility;

namespace Mango.Web.Services.Auth
{
    //use cookies to store tokens 
    public class TokenProvider(IHttpContextAccessor _contextAccessor) : ITokenProvider
    {

        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);
            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
