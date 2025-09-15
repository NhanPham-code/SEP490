using FavoriteAPI.Data;
using FavoriteAPI.Model;
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
    odataBuilder.EntitySet<Favorite>("ODataFavorites"); // <--- Tên EntitySet là "ODataFavorites" giống như route của ODataFavoritesController

    // Rất quan trọng: Đăng ký ReadUserDTO là một EntityType hoặc ComplexType
    // Việc này giúp OData hiểu cấu trúc của DTO cho các phép chiếu và metadata.
    // Nếu ReadUserDTO có một thuộc tính đóng vai trò là key (ví dụ UserId),
    // bạn có thể đăng ký nó là EntityType. Nếu không, là ComplexType.

    //odataBuilder.EntityType<PrivateUserProfileDTO>(); // <--- Thêm dòng này

    return odataBuilder.GetEdmModel();
}

// 2. Add OData services
builder.Services.AddControllers().AddOData(options =>
{
    // Đăng ký route components cho ODataFavoritesController
    // Tiền tố "odata" phải khớp với [Route("odata/[controller]")] của ODataFavoritesController
    options.AddRouteComponents("odata", GetEdmModel()) // route: /odata/ODataFavorites
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
builder.Services.AddDbContext<FavoriteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inject Mapping Profiles
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Inject Repositories and Services
builder.Services.AddScoped<FavoriteAPI.Repository.Interface.IFavoriteRepository, FavoriteAPI.Repository.FavoriteRepository>();
builder.Services.AddScoped<FavoriteAPI.Service.Interface.IFavoriteService, FavoriteAPI.Service.FavoriteService>();

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
