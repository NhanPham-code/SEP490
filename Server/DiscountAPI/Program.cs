using DiscountService.Data;
using Microsoft.EntityFrameworkCore;
using DiscountAPI.Profiles;
using DiscountAPI.Respository.Interface;
using DiscountAPI.Respository;
using DiscountAPI.Service.Interface;
using DiscountAPI.Service;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Models;
using DiscountAPI.DTO;
using Microsoft.OData.Edm;
using Hangfire;

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

// Authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("StadiumManager", policy => policy.RequireRole("StadiumManager"));
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
static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<ReadDiscountDTO>("ODataDiscount")
           .EntityType.HasKey(d => d.Id);
    return builder.GetEdmModel();
}


builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100);
});

// Swagger + JWT config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"))); // Dùng chung chuỗi kết nối với DB chính

// 2. ADD HANGFIRE SERVER (Worker xử lý ngầm)
builder.Services.AddHangfireServer();

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

app.UseAuthentication(); 
app.UseAuthorization();

app.UseHangfireDashboard(); 

// Tạo Recurring Job: Chạy mỗi ngày một lần vào lúc 00:00 (nửa đêm)
RecurringJob.AddOrUpdate<IDiscountService>(
    "auto-deactivate-expired-discounts",
    service => service.ScanAndDeactivateExpiredDiscountsAsync(),
    Cron.Daily);


app.MapControllers();

app.Run();
