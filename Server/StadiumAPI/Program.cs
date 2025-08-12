using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
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

var odataBuilder = new ODataConventionModelBuilder();
// odata
odataBuilder.EntitySet<ReadStadiumDTO>("Stadiums")
    .EntityType.HasKey(s => s.Id);
odataBuilder.EntityType<ReadStadiumDTO>();

builder.Services.AddControllers().AddOData(options => options
.AddRouteComponents("odata", odataBuilder.GetEdmModel()).Select().Filter().OrderBy().Expand().Count().SetMaxTop(100));
odataBuilder.EntitySet<Stadiums>("OdataStadium");


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
