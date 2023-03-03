using netcore_app;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using netcore_app.Common;
using netcore_app.IServices;
using netcore_app.IRepositories;
using netcore_app.Services;
using netcore_app.Repositories;
using Scrutor;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySQLConnection"))));
// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers(opt =>
{
  opt.UseCentralRoutePrefix(new RouteAttribute("api")); // 自定义路由前缀
  opt.Filters.Add(typeof(ApiResultFilterAttribute)); // 返回内容统一封装
  opt.Filters.Add(typeof(ApiExceptionsFilter)); // 异常统一处理
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// swagger注册
builder.Services.AddSwaggerGen();

// 序列化
builder.Services.AddMvc().AddJsonOptions((options) =>
{
  options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter()); // 时间格式化
});

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

