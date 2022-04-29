using ImaginaryCardsGame.Backend.Services;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// enable Swagger in All environment
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();