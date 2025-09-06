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
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    // Stadiums
    var stadium = odataBuilder.EntitySet<Stadiums>("OdataStadium");
    stadium.EntityType.HasKey(s => s.Id);
    // Khai báo navigation property
    stadium.EntityType.HasMany(s => s.Courts);
    stadium.EntityType.HasMany(s => s.StadiumImages);
    // Khai báo binding (liên kết)
    stadium.HasManyBinding(s => s.Courts, "Courts");
    stadium.HasManyBinding(s => s.StadiumImages, "StadiumImages");
    stadium.HasManyBinding(s => s.StadiumVideos, "StadiumVideos");

    // Courts
    var court = odataBuilder.EntitySet<Courts>("Courts");
    court.EntityType.HasKey(c => c.Id);
    court.EntityType.HasRequired(c => c.Stadium);
    court.HasRequiredBinding(c => c.Stadium, "OdataStadium");

    // StadiumImages
    var stadiumImage = odataBuilder.EntitySet<StadiumImages>("StadiumImages");
    stadiumImage.EntityType.HasKey(si => si.Id);
    stadiumImage.EntityType.HasOptional(si => si.Stadium);
    stadiumImage.HasOptionalBinding(si => si.Stadium, "OdataStadium");

    // stadium Video
    var stadiumVideo = odataBuilder.EntitySet<StadiumVideos>("StadiumVideos");
    stadiumImage.EntityType.HasKey(si => si.Id);
    stadiumImage.EntityType.HasOptional(si => si.Stadium);
    stadiumImage.HasOptionalBinding(si => si.Stadium, "OdataStadium");

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

builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Register repositories
builder.Services.AddScoped<IStadiumRepositories, StadiumRepositories>();
builder.Services.AddScoped<IStadiumImagesRepositories, StadiumImageRepositories>();
builder.Services.AddScoped<ICourtsRepositories, CourtsRepositories>();
builder.Services.AddScoped<ICourtRelationRepositories, CourtRelationRepositories>();
builder.Services.AddScoped<IStadiumVideosRepositories, StadiumVideoRepositories>();

// Register services
builder.Services.AddScoped<IServiceStadium, ServiceStadium>();
builder.Services.AddScoped<IStadiumImagesService, StadiumImagesService>();
builder.Services.AddScoped<ICourtsService, CourtsService>();
builder.Services.AddScoped<ICourtRelationService, CourtRelationService>();
builder.Services.AddScoped<IStadiumVideosService, StadiumVideoService>();

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