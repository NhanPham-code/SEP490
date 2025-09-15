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
builder.Services.AddScoped<IStadiumImageService, StadiumImageService>();

builder.Services.AddScoped<IFeedbackService, FeedbackService>();

builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ICourtRelationService, CourtRelationService>();
builder.Services.AddScoped<ITeamPostService, TeamPostService>();
builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true // Cho phép phục vụ các loại file không xác định
});

app.UseRouting();

app.UseMiddleware<NoCacheMiddleware>(); // <-- ĐĂNG KÝ MIDDLEWARE CỦA BẠN

app.UseSession();

app.UseMiddleware<TokenRefreshMiddleware>(); // <-- ĐĂNG KÝ MIDDLEWARE CỦA BẠN

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<TokenSessionMiddleware>(); // <-- ĐĂNG KÝ MIDDLEWARE CỦA BẠN

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
