using DiscountService.Data;
using Microsoft.EntityFrameworkCore;
using DiscountAPI.Profiles;
using DiscountAPI.Respository.Interface;
using DiscountAPI.Respository;
using DiscountAPI.Service.Interface;
using DiscountAPI.Service;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using DiscountAPI.DTO;

var builder = WebApplication.CreateBuilder(args);

// ==================== Add Services ====================

// DbContext
builder.Services.AddDbContext<DiscountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(DiscountProfile));

// DI for Repository & Service
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountService, DiscountAPI.Service.DiscountService>();

// OData Model configuration
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<ReadDiscountDTO>("Discounts");

// Add Controllers + OData
builder.Services.AddControllers()
    .AddOData(options => options
        .EnableQueryFeatures() // Enable $filter, $orderby, etc.
        .AddRouteComponents("api", odataBuilder.GetEdmModel())); // Use OData on "api"

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==================== Build & Run ====================
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
