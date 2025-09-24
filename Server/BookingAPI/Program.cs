using BookingAPI.Data;
using BookingAPI.Models;
using BookingAPI.Profiles;
using BookingAPI.Repository;
using BookingAPI.Repository.Interface;
using BookingAPI.Services;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configure OData EDM Model
static Microsoft.OData.Edm.IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();

    // Khai báo EntitySet và key
    builder.EntitySet<Booking>("Bookings")
           .EntityType.HasKey(b => b.Id);

    builder.EntitySet<BookingDetail>("BookingDetails")
           .EntityType.HasKey(d => d.Id);
    builder.EntitySet<MonthlyBooking>("OdataMonthlyBooking")
           .EntityType.HasKey(d => d.Id);

    return builder.GetEdmModel();
}

// Add services to the container.
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100)
        .AddRouteComponents("odata", GetEdmModel()));

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

// Authorization policies (cho phép Customer) ?? dùng trong Controller
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

// Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
builder.Services.AddScoped<IMonthlyBookingRepository, MonthlyBookingRepository>();

// Services
builder.Services.AddScoped<IBookingService, BookingService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(BookingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();