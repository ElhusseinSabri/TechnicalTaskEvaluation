using MainDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0))
    ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReviewingRepository, ReviewingRepository>();
builder.Services.AddScoped<IReviewingService, ReviewingService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();




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

app.Run();
