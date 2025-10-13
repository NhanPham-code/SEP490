
﻿using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

﻿using Middlewares;

using Service.BaseService;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Cho phép upload file lớn
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 50000000; // hoặc số cụ thể, ví dụ 500_000_000 cho 500MB
});

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new SimpleTypeModelBinderProvider());
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddControllersWithViews();

// Cookies
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.LoginPath = "/Login"; // Redirect khi chưa login
        options.AccessDeniedPath = "/AccessDenied";
    });

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// HttpClient
builder.Services.AddHttpClient<GatewayHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7136/");
});

// IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IStadiumImageService, StadiumImageService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ICourtService, CourtService>();
builder.Services.AddScoped<ICourtRelationService, CourtRelationService>();
builder.Services.AddScoped<IStadiumVideoSetvice, StadiumVideoService>();
builder.Services.AddScoped<IStadiumEquipmentService, StadiumEquipmentService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
var app = builder.Build();
app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Đặt middleware NoCache ở đây, trước khi phục vụ bất kỳ file nào
app.UseMiddleware<NoCacheMiddleware>();

app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true
});

app.UseRouting();

app.UseSession();

app.UseMiddleware<TokenRefreshMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<TokenSessionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Common}/{action=Login}/{id?}");

app.Run();