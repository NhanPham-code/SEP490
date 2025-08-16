using BookingAPI.Data;
using BookingAPI.Repository.Interface;
using BookingAPI.Repository;
using BookingAPI.Services.Interface;
using BookingAPI.Services;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Profiles;
using BookingAPI.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

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

// Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

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
app.UseAuthorization();

app.MapControllers();

app.Run();