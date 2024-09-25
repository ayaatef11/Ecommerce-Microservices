using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Mapping;
using Mango.Services.CouponApi.Seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CouponContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("CouponConnection")));
MappingConfiguration.RegisterMappings();
builder.Services.AddScoped<CouponSeeder>();

var settingsSection = builder.Configuration.GetSection("ApiSettings");

var secret = settingsSection.GetValue<string>("Secret");
var issuer = settingsSection.GetValue<string>("Issuer");
var audience = settingsSection.GetValue<string>("Audience");

var key = Encoding.ASCII.GetBytes(secret);

/*
The [Authorize] attribute in ASP.NET Core is used to specify that access to a controller or an action method requires the user to be authenticated or to meet certain authorization requirements. For it to work properly, a few things are needed:

1. Authentication Scheme
The application must be configured with an authentication scheme, typically JWT (JSON Web Token) or cookie-based authentication. This allows the application to authenticate the user based on a token, cookie, or other authentication mechanism.

Example configuration for JWT in Program.cs or Startup.cs:

csharp
Copy code
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourIssuer",
            ValidAudience = "yourAudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey"))
        };
    });
With JWT authentication, users must provide a valid JWT in the Authorization header of their HTTP requests.

2. Authentication Token (JWT or Cookies)
The user must be authenticated using a token, such as a JWT, which will be passed to the server as part of each request.

In the case of JWT, the request header should contain the token:

makefile
Copy code
Authorization: Bearer YOUR_JWT_TOKEN
In cookie-based authentication, the server sets an authentication cookie after the user logs in, and the browser automatically sends the cookie with each request.

3. Authorization Setup
In addition to being authenticated, users might need to meet specific authorization requirements, like having certain roles or claims. The [Authorize] attribute can specify different levels of authorization:

Generic Authentication: Requires the user to be authenticated.

csharp
Copy code
[Authorize]
Role-Based Authorization: Requires the user to belong to a certain role, such as "Admin."

csharp
Copy code
[Authorize(Roles = "Admin")]
Policy-Based Authorization: Requires the user to meet a custom policy defined in the application.

csharp
Copy code
[Authorize(Policy = "RequireAdminRole")]
Policies can be configured in Program.cs or Startup.cs like this:

csharp
Copy code
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});
4. Middleware Setup
The application must be configured to use authentication and authorization middleware to validate user credentials and permissions for each request.

Middleware setup typically looks like this:

csharp
Copy code
app.UseAuthentication(); // Enables authentication middleware
app.UseAuthorization();  // Enables authorization middleware
5. Authentication Scheme Dependencies
The [Authorize] attribute works in conjunction with the authentication mechanism you've set up, such as:

JWT Token: Issued during login and used to authenticate API calls.
Cookies: Set when a user logs in and automatically sent with subsequent requests.
OAuth or OpenID Connect: Used for external authentication providers like Google, Facebook, etc.*/

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    //these attributes make the user in the authentication
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        ValidateAudience = true
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: 'Bearer Generated-JWT-Token'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Bearer",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>() // This was missing in your code
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await migrateCoupons(app);

app.Run();
 async Task migrateCoupons(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;

    var _storeContext = services.GetRequiredService<CouponContext>();

    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var seeder = scope.ServiceProvider.GetRequiredService<CouponSeeder>();

    try
    {

       await  _storeContext.Database.MigrateAsync();
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "an error has been occured during apply the migration");
    }

}
