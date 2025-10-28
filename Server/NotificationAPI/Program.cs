using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using NotificationAPI.Data;
using NotificationAPI.Hubs;
using NotificationAPI.Model;
using NotificationAPI.Repository;
using NotificationAPI.Repository.Interface;
using NotificationAPI.Service;
using NotificationAPI.Service.Interface;
using System.Text;


using Microsoft.AspNetCore.SignalR;
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

    // Vẫn đăng ký EntitySet cho Notification (entity gốc từ DB)
    odataBuilder.EntitySet<Notification>("ODataNotifications"); // <--- Tên EntitySet là "ODataNotifications" giống như route của ODataNotificationsController

    // Rất quan trọng: Đăng ký ReadUserDTO là một EntityType hoặc ComplexType
    // Việc này giúp OData hiểu cấu trúc của DTO cho các phép chiếu và metadata.
    // Nếu ReadUserDTO có một thuộc tính đóng vai trò là key (ví dụ UserId),
    // bạn có thể đăng ký nó là EntityType. Nếu không, là ComplexType.
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
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true) // hoặc .WithOrigins("http://localhost:3000") với frontend cụ thể
            .AllowCredentials();
    });
});
// Inject DB
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inject Repositories
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

// Inject Services
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddSignalR();

builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

// Inject AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Phải đặt trước UseAuthorization và MapHub

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();
