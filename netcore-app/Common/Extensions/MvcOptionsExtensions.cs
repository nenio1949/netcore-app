﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace netcore_app.Common
{
  public static class MvcOptionsExtensions
  {
    /// <summary>
    /// 使用自定义路由扩展方法
    /// </summary>
    /// <param name="opts"></param>
    /// <param name="routeAttribute"></param>
    public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
    {
      // 添加我们自定义 实现IApplicationModelConvention的RouteConvention
      opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
    }
  }
}

