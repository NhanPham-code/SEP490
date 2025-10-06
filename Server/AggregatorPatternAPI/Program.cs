using AggregatorPatternAPI.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Thêm services vào container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Đăng ký Aggregator Service
builder.Services.AddScoped<IAggregatorService, AggregatorService>();

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