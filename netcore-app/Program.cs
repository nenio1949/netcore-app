using netcore_app;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using netcore_app.Common.AutoMapper;
using netcore_app.IServices;
using netcore_app.IRepositories;
using netcore_app.Services;
using netcore_app.Repositories;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySQLConnection"))));
// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// swagger注册
builder.Services.AddSwaggerGen();

// service及repository批量注册
//builder.Services.AddScoped<IRoleService, RoleService>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.Scan(
    scan => scan
    .FromAssemblyOf<Program>()

    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)
        ))
    // 防止重复注册
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsImplementedInterfaces()
    .WithScopedLifetime()

    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)
        ))
    // 防止重复注册
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsImplementedInterfaces()
    .WithScopedLifetime()
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

