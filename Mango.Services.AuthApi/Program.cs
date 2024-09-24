using Mango.Services.AuthApi.Data;
using Mango.Services.AuthApi.Interfaces.Interfaces;
using Mango.Services.AuthApi.Interfaces.Services;
using Mango.Services.AuthApi.Models;
using Mango.Services.AuthApi.Seeding;
using Mango.Services.AuthApi.Services;
using Mango.Services.AuthApi.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AuthContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AuthSeeder>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await migrateUsers(app);

app.Run();

static async Task migrateUsers(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;

    var _storeContext = services.GetRequiredService<AuthContext>();

    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var seeder = scope.ServiceProvider.GetRequiredService<AuthSeeder>();

    try
    {

        await _storeContext.Database.MigrateAsync();
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "an error has been occured during apply the migration");
    }

}
