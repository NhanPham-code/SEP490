using AggregatorPatternAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Thêm services vào container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Thêm định nghĩa về Security Scheme cho JWT Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập 'Bearer' [dấu cách] và sau đó là token của bạn vào ô bên dưới.\n\nVí dụ: \"Bearer 12345abcdef\""
    });

    // Yêu cầu tất cả các endpoint phải sử dụng security scheme đã định nghĩa ở trên
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Cấu hình HttpClientFactory
builder.Services.AddHttpClient("StadiumAPI", client =>
{
    // Thêm ! để báo cho trình biên dịch rằng giá trị sẽ không null (Non-nullable)
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:StadiumApiUrl"]!); 
});
builder.Services.AddHttpClient("BookingAPI", client =>
{
    // Thêm !
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BookingApiUrl"]!);
});
builder.Services.AddHttpClient("UserAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:UserApiUrl"]!);
});
builder.Services.AddHttpClient("FeedbackAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:FeedbackApiUrl"]!);
});

// Đăng ký Aggregator Service
builder.Services.AddScoped<IAggregatorService, AggregatorService>();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();