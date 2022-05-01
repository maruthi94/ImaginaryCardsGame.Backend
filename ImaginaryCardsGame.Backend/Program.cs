using ImaginaryCardsGame.Backend.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICardsSortService, CardsSortService>();

builder.Services.AddControllers();

//Add Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder
                        => builder.WithOrigins("https://*.azurewebsites.net", "https://*.azurestaticapps.net", "http://localhost:4200")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Imaginary Cards Game API's",
        Description = "An ASP.NET Core Web API for managing 'Imaginary Cards Game'",
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
var app = builder.Build();

// enable Swagger in All environment
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();