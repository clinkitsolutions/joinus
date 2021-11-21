using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod(); ;
        builder.WithOrigins("http://localhost:4200", "https://localhost:4200");
        builder.AllowAnyHeader();
        builder.AllowCredentials();
    });
});
services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

services.AddVehicleService(configuration.GetSection("VehicleService"), Assembly.GetExecutingAssembly());

// Add Swagger UI
services.AddApiDocumentation();

// Build the app and configure the request pipeline
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseApiDocumentation();
app.Run();