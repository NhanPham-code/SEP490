using FeedbackAPI.Data;
using FeedbackAPI.Mapper;
using FeedbackAPI.Repository;
using FeedbackAPI.Service;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ===== JWT Authentication =====
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

// ===== CORS ===== (Cập nhật)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7128", "http://localhost:7128") // Thêm cả http
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Thêm dòng này
    });

    // Hoặc dùng policy rộng hơn để test
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// ===== Authorization Policies =====
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

// ===== OData + Controllers =====
builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select()
               .Filter()
               .OrderBy()
               .Expand()
               .Count()
               .SetMaxTop(100)
               .AddRouteComponents("odata", GetEdmModel());
        // route là "/odata"
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===== DbContext =====
builder.Services.AddDbContext<FeedbackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== Repository & Service =====
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

// ===== AutoMapper =====
builder.Services.AddAutoMapper(typeof(FeedbackProfile));

var app = builder.Build();

// ===== Middleware Pipeline =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// ⚡ Thêm CORS ở đây (phải trước Authentication/Authorization)
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// ===== EDM Model for OData =====
IEdmModel GetEdmModel()
{
    var modelBuilder = new ODataConventionModelBuilder();
    // EntitySet phải trùng với Controller: FeedbackODataController
    modelBuilder.EntitySet<FeedbackAPI.Models.Feedback>("FeedbackOData");
    return modelBuilder.GetEdmModel();
}
