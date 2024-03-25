using Domain.DTO;
using Domain.Entities;
using Domain.Repository;
using Domain.Repository.Base;
using Domain.RepositoryContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CobaContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CobaDB")));

builder.Services.AddScoped<IRepositoryEntityBase<User, UserRequest>, UserRepository>();
builder.Services.AddScoped<IRepositoryEntityBase<Role, RoleRequest>, RoleRespository>();
builder.Services.AddScoped<IRepositoryEntityBase<Permission, PermissionRequest>, PermissionRespository>();

builder.Services.AddCors(options => { options.AddPolicy(name: "cors", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("cors");
app.UseAuthorization();

app.MapControllers();

app.Run();
