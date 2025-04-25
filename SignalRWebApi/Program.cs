using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Concrete;
using SignalRBusinessLayer.Conteiner;
using SignalRWebApi.Mapping;
using SignalRWebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed(_ => true)  // Her yerden izin verir
              .AllowCredentials();
    });
});

// SignalR
builder.Services.AddSignalR();

// EF Core - SQL Server
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.ConteinerDependencies();

// AutoMapper
builder.Services.AddAutoMapper(typeof(GeneralMapping));

// MVC Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
