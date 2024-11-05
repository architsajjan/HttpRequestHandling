using HttpRequestHandling.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

// --------------- HTTP Client Factory Additions -------------
builder.Services.AddHttpClient();

#region Named Client
builder.Services.AddHttpClient("Weather", c =>
{
    c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
    c.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
    c.DefaultRequestVersion = new Version(1, 1);

});
#endregion

#region Typed Client
builder.Services.AddHttpClient<IWeatherService, WeatherService>(c =>
{
    c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
});
#endregion
// ---------------


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
