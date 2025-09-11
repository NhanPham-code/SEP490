using FindTeamAPI.Data;
using FindTeamAPI.Models;
using FindTeamAPI.Repositories;
using FindTeamAPI.Repositories.Interface;
using FindTeamAPI.Service;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    // Stadiums
    var stadium = odataBuilder.EntitySet<TeamPost>("OdataTeamPost");
    stadium.EntityType.HasKey(s => s.Id);
    // Khai báo navigation property
    stadium.EntityType.HasMany(s => s.TeamMembers);

    // Khai báo binding (liên kết)
    stadium.HasManyBinding(s => s.TeamMembers, "TeamMembers");


    // Courts
    var court = odataBuilder.EntitySet<TeamMember>("TeamMembers");
    court.EntityType.HasKey(c => c.Id);
    court.EntityType.HasRequired(c => c.TeamPost);
    court.HasRequiredBinding(c => c.TeamPost, "OdataTeamPost");


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

builder.Services.AddScoped<ITeamPostRepositories, TeamPostRepositories>();
builder.Services.AddScoped<ITeamMemberRepositories, TeamMemberRepositories>();

// Register services
builder.Services.AddScoped<ITeamPostService, TeamPostService>();
builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add DbContext and other services as needed
// Example: 
builder.Services.AddDbContext<FindTeamDbContext>(options => options.UseSqlServer
     (builder.Configuration.GetConnectionString("DefaultConnection")));

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
