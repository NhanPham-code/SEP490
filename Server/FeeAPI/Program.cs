using FeeAPI.Data;
using FeeAPI.Model;
using FeeAPI.Repository;
using FeeAPI.Repository.Interface;
using FeeAPI.Service;
using FeeAPI.Service.Interface;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Build EDM model
IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    // Vẫn đăng ký EntitySet cho User (entity gốc từ DB)
    odataBuilder.EntitySet<Fee>("ODataFees"); // <--- Tên EntitySet là "ODataUsers" giống như route của ODataUsersController

    // Rất quan trọng: Đăng ký ReadUserDTO là một EntityType hoặc ComplexType
    // Việc này giúp OData hiểu cấu trúc của DTO cho các phép chiếu và metadata.
    // Nếu ReadUserDTO có một thuộc tính đóng vai trò là key (ví dụ UserId),
    // bạn có thể đăng ký nó là EntityType. Nếu không, là ComplexType.

    //odataBuilder.EntityType<PrivateUserProfileDTO>();

    return odataBuilder.GetEdmModel();
}

// 2. Add OData services
builder.Services.AddControllers().AddOData(options =>
{
    // Đăng ký route components cho ODataUsersController
    // Tiền tố "odata" phải khớp với [Route("odata/[controller]")] của ODataUsersController
    options.AddRouteComponents("odata", GetEdmModel()) // route: /odata/ODataUsers
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100);
});

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

// Inject DB
builder.Services.AddDbContext<FeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inject Repositories
builder.Services.AddScoped<IFeeRepository, FeeRepository>();

// Inject Services
builder.Services.AddScoped<IFeeService, FeeService>();
builder.Services.AddHttpClient<IBookingService, BookingService>();
builder.Services.AddHttpClient<IStadiumService, StadiumService>();
builder.Services.AddScoped<IFeeCalculationService, FeeCalculationService>();

// Thêm dịch vụ Memory Cache
builder.Services.AddMemoryCache();

// Inject AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// HANGFIRE: Bắt đầu cấu hình Hangfire Services
var hangfireConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(hangfireConnectionString, new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

// Thêm Hangfire Server để xử lý các job trong background
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// HANGFIRE: Thêm Dashboard UI
// Đặt sau UseAuthorization để có thể lấy thông tin User
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

// HANGFIRE: Lên lịch cho công việc định kỳ
// Chạy vào 00:05 ngày 1 hàng tháng (giờ UTC)
RecurringJob.AddOrUpdate<IFeeCalculationService>(
    "calculate-monthly-fees", // Tên định danh của job
    service => service.GenerateFeesForPreviousMonthAsync(),
    "5 0 1 * *"); // CRON expression

app.MapControllers();

app.Run();

// HANGFIRE: Helper class để bảo vệ Dashboard
public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        // Chỉ cho phép truy cập nếu user đã đăng nhập và có role "Admin"
        //return httpContext.User.Identity?.IsAuthenticated == true && httpContext.User.IsInRole("Admin");
        return true;
    }
}
