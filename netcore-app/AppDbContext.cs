using System;
using System.Reflection;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;
using netcore_app.Models;
using System.ComponentModel;
using System.Reflection.Emit;

namespace netcore_app
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLoggerFactory(MyLoggerFactory);
      optionsBuilder.EnableSensitiveDataLogging();
      optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
      if (assemblyName != null)
      {
        var entityTypes = Assembly.Load(new AssemblyName(assemblyName)).GetTypes()
            .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
            .Where(type => type.GetTypeInfo().IsClass)
        .Where(type => type.GetTypeInfo().BaseType != null)
            .Where(type => typeof(IEntity).IsAssignableFrom(type)).ToList();

        foreach (var entityType in entityTypes)
        {

          if (entityType == null)
            continue;

          if (entityType.Name == "EntityBase")
            continue;

          //  防止重复附加模型，否则会在生成指令中报错
          if (builder.Model.FindEntityType(entityType) != null)
            continue;

          builder.Model.AddEntityType(entityType);
        }

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
          if (entityType == null)
            continue;
          if (entityType.Name == "EntityBase")
            continue;
          var type = entityType.ClrType;
          if (typeof(IEntity).IsAssignableFrom(type))
          {
            //通过DescriptionAttribute创建字段注释
            var descriptionAttrs = type.GetProperties().Where(c => c.IsDefined(typeof(DescriptionAttribute), true));
            foreach (var attr in descriptionAttrs)
            {
              var descriptionAttr = attr.GetCustomAttribute<DescriptionAttribute>();
              builder.Entity(type).Property(attr.Name).HasComment(descriptionAttr?.Description);
            }
          }
        }

        base.OnModelCreating(builder);
      }
    }

    public override int SaveChanges()
    {
      SetSystemField();
      return base.SaveChanges();
    }

    /// <summary>
    /// 重写saveChange，自动赋值创建、更新时间
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      SetSystemField();
      return base.SaveChangesAsync();
    }

    /// <summary>
    /// 系统字段赋值
    /// </summary>
    private void SetSystemField()
    {
      foreach (var item in ChangeTracker.Entries())
      {
        if (item.Entity is EntityBase)
        {
          var entity = (EntityBase)item.Entity;
          //添加操作
          if (item.State == EntityState.Added)
          {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
          }
          //修改操作
          else if (item.State == EntityState.Modified)
          {
            entity.UpdatedAt = DateTime.Now;
          }
        }

      }
    }
  }
}

