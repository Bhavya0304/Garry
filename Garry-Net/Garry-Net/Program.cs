using Garry_Net;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var config = builder.Build();

var builderWeb = WebApplication.CreateBuilder(args);
builderWeb.Services.AddControllers();
builderWeb.Services.AddEndpointsApiExplorer();
builderWeb.Services.AddSingleton<IConfiguration>(config);

var app = builderWeb.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
