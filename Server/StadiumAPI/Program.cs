using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using StadiumAPI.Data;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service;
using StadiumAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    // Đăng ký EntitySet cho Stadiums
    var stadium = odataBuilder.EntitySet<Stadiums>("Stadiums");
    stadium.EntityType.HasKey(s => s.Id);
    stadium.HasManyBinding(s => s.Courts, "Courts");
    stadium.HasManyBinding(s => s.StadiumImages, "StadiumImages");

    // Đăng ký EntitySet cho Courts
    var court = odataBuilder.EntitySet<Courts>("Courts");
    court.EntityType.HasKey(c => c.Id);
    court.HasRequiredBinding(c => c.Stadium, "Stadiums"); // Quan hệ n-1 với Stadiums

    // Đăng ký EntitySet cho StadiumImages
    var stadiumImage = odataBuilder.EntitySet<StadiumImages>("StadiumImages");
    stadiumImage.EntityType.HasKey(si => si.Id);
    stadiumImage.HasOptionalBinding(si => si.Stadium, "Stadiums"); // Quan hệ n-1 với Stadiums

    // Rất quan trọng: Đăng ký ReadUserDTO là một EntityType hoặc ComplexType
    // Việc này giúp OData hiểu cấu trúc của DTO cho các phép chiếu và metadata.
    // Nếu ReadUserDTO có một thuộc tính đóng vai trò là key (ví dụ UserId),
    // bạn có thể đăng ký nó là EntityType. Nếu không, là ComplexType.

    odataBuilder.EntityType<ReadStadiumDTO>(); // <--- Thêm dòng này

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


builder.Services.AddDbContext<StadiumDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Register repositories
builder.Services.AddScoped<IStadiumRepositories, StadiumRepositories>();
builder.Services.AddScoped<IStadiumImagesRepositories, StadiumImageRepositories>();
builder.Services.AddScoped<ICourtsRepositories, CourtsRepositories>();

// Register services
builder.Services.AddScoped<IServiceStadium, ServiceStadium>();
builder.Services.AddScoped<IStadiumImagesService, StadiumImagesService>();
builder.Services.AddScoped<ICourtsService, CourtsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
