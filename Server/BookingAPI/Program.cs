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
using Hangfire; // Đảm bảo bạn đã có using này

var builder = WebApplication.CreateBuilder(args);

// Đặt một tên cho policy CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Configure OData EDM Model
static Microsoft.OData.Edm.IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Booking>("Bookings").EntityType.HasKey(b => b.Id);
    builder.EntitySet<BookingDetail>("BookingDetails").EntityType.HasKey(d => d.Id);
    builder.EntitySet<MonthlyBooking>("OdataMonthlyBooking").EntityType.HasKey(d => d.Id);
    builder.EntitySet<Booking>("Bookings").EntityType.HasKey(b => b.Id);
    builder.EntitySet<BookingDetail>("BookingDetails").EntityType.HasKey(d => d.Id);
    builder.EntitySet<MonthlyBooking>("OdataMonthlyBooking").EntityType.HasKey(d => d.Id);
    return builder.GetEdmModel();
}

// === SỬA LỖI: GIỮ LẠI CÁCH VIẾT NỐI CHUỖI ĐÚNG CÚ PHÁP ===
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100)
        .AddRouteComponents("odata", GetEdmModel())); // Prefix "odata" sẽ giúp OData không xung đột với API thường

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

// Authorization policies
// Authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("StadiumManager", policy => policy.RequireRole("StadiumManager"));
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5020")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories & Services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
builder.Services.AddScoped<IMonthlyBookingRepository, MonthlyBookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(BookingProfile));

// HangFire
// Lấy chuỗi kết nối database từ file appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Thêm các dịch vụ của Hangfire và chỉ cho nó nơi lưu trữ job (dùng SQL Server)
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(connectionString));

// Thêm Hangfire Server để nó có thể bắt đầu xử lý các job trong nền
builder.Services.AddHangfireServer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Thứ tự Middleware
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard();

// Tự động cập nhật ở phút thứ 0 mỗi giờ
RecurringJob.AddOrUpdate<IBookingService>(
    "complete-past-bookings",
    service => service.AutoCompleteBookingsAsync(),
    "0 * * * *");
app.MapControllers();

app.Run();