using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Mapping;
using Mango.Services.CouponApi.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CouponContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("CouponConnection")));
MappingConfiguration.RegisterMappings();
builder.Services.AddScoped<CouponSeeder>();
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

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
