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
    builder.EntitySet<Booking>("Bookings");
    builder.EntitySet<BookingDetail>("BookingDetails");
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

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

// Add services
builder.Services.AddScoped<IBookingService, BookingService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(BookingProfile));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
