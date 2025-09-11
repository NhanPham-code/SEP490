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
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// ==================== Add Services ====================

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],

            ValidateAudience = true,
            ValidAudience = jwtSettings["Audience"],

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Authorization policies (cho phép Customer) để dùng trong Controller
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy =>
    {
        policy.RequireRole("Customer");
    });

    options.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");
    });

    options.AddPolicy("StadiumManager", policy =>
    {
        policy.RequireRole("StadiumManager");
    });
});

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
