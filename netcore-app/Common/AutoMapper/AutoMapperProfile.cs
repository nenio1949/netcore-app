using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace netcore_app.Common
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
      var filePath = Path.Combine(basePath, "netcore-app.dll");
      var entityTypes = Assembly.LoadFrom(filePath).GetTypes()
        .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
        .Where(type => type.GetTypeInfo().IsClass)
        .Where(type => type.GetCustomAttribute<AutoInjectAttribute>() != null).ToList();

      foreach (var entityType in entityTypes)
      {
        var injectAttribute = entityType.GetCustomAttribute<AutoInjectAttribute>();
        if (injectAttribute != null)
        {
          var targetType = injectAttribute.TargetType;

          CreateMap(entityType, targetType);
          CreateMap(targetType, entityType);
        }
      }
    }
  }
}

