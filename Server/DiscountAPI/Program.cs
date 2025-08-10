using DiscountService.Data;
using Microsoft.EntityFrameworkCore;
using DiscountAPI.Profiles;
using DiscountAPI.Respository.Interface;
using DiscountAPI.Respository;
using DiscountAPI.Service.Interface;
using DiscountAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<DiscountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DiscountConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(DiscountProfile)); // Sửa nếu tên profile khác

// Add Dependency Injection
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountService, DiscountAPI.Service.DiscountService>();


// Add Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
