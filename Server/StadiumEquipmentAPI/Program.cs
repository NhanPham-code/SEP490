using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using StadiumEquipmentAPI.Data;
using StadiumEquipmentAPI.Mapper;
using StadiumEquipmentAPI.Repository;
using StadiumEquipmentAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// ===== Controllers + OData =====
builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select()
               .Filter()
               .OrderBy()
               .Expand()
               .Count()
               .SetMaxTop(100)
               .AddRouteComponents("odata", GetEdmModel()); // route: /odata
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===== DbContext =====
builder.Services.AddDbContext<StadiumEquipmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== Repository & Service =====
builder.Services.AddScoped<IStadiumEquipmentRepository, StadiumEquipmentRepository>();
builder.Services.AddScoped<IStadiumEquipmentService, StadiumEquipmentService>();
builder.Services.AddScoped<IFileService, FileService>();

// ===== AutoMapper =====
builder.Services.AddAutoMapper(typeof(StadiumEquipmentProfile));

var app = builder.Build();

// ===== Middleware Pipeline =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// ===== EDM Model for OData =====
IEdmModel GetEdmModel()
{
    var modelBuilder = new ODataConventionModelBuilder();
    // EntitySet trùng với controller: StadiumEquipmentODataController
    modelBuilder.EntitySet<StadiumEquipmentAPI.Models.StadiumEquipments>("StadiumEquipmentOData");
    return modelBuilder.GetEdmModel();
}
