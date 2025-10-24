using Middlewares;
using Service.BaseService;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cookies
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.LoginPath = "/Login"; // Redirect khi chưa login
        options.AccessDeniedPath = "/AccessDenied";
    });

// Session
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
builder.Services.AddScoped<IStadiumVideoSetvice, StadiumVideoService>();
builder.Services.AddScoped<IStadiumImageService, StadiumImageService>();
builder.Services.AddScoped<ICourtService, CourtService>();
builder.Services.AddScoped<ICourtRelationService, CourtRelationService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFeesService, FeesService>();


var app = builder.Build();

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
