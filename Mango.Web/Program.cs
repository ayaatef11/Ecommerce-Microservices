using Mango.Web.Interfaces.Services;
using Mango.Web.Interfaces.Services.Auth;
using Mango.Web.Interfaces.Services.Coupons;
using Mango.Web.Services;
using Mango.Web.Services.Auth;
using Mango.Web.Services.Coupons;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
//register an httpclient for the authservice
builder.Services.AddHttpClient<IAuthService, AuthService>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBaseService, BaseService>();

//components of a cookie 
//sessionID=abc123: The cookie contains a session ID.
//Domain = example.com: The cookie is valid for the example.com domain.
//Path=/: The cookie is sent for all paths on the domain.
//Expires=Wed, 29 Sep 2024 10:00:00 GMT: The cookie will expire on this date.
//Secure: The cookie will only be sent over HTTPS.
//HttpOnly: The cookie is not accessible via JavaScript (protects against XSS).
//SameSite=Lax: The cookie is only sent for top-level navigations within the same site.

//configurations for cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(10);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
