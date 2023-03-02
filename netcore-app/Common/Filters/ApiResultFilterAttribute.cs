using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace netcore_app.Common.Filters
{
    /// <summary>
    /// Api action统一处理过滤器  
    /// 处理正常返回值
    /// </summary>
    public class ApiResultFilterAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// 执行方法体之后
        /// 返回结果为JsonResult的请求进行Result包装
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // 返回结果为JsonResult的请求进行Result包装
            if (context.Result != null)
            {
                if (context.Result is ObjectResult)
                {
                    var result = context.Result as ObjectResult;
                    context.Result = new JsonResult(new ApiResult() { Code = System.Net.HttpStatusCode.OK, Message = "success", Data = result?.Value, Success = true });

                }
                else if (context.Result is EmptyResult)
                {
                    context.Result = new JsonResult(new ApiResult() { Code = System.Net.HttpStatusCode.OK, Message = "success", Success = true });
                }
                else if (context.Result is ContentResult)
                {
                    var result = context.Result as ContentResult;
                    context.Result = new JsonResult(new ApiResult() { Code = System.Net.HttpStatusCode.OK, Message = result?.Content });
                }
                else
                {
                    throw new Exception($"未经处理的Result类型：{context.Result.GetType().Name}");
                }

            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var msg = "";

                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        msg += error.ErrorMessage + "|";
                    }
                }

                context.Result = new ObjectResult(
                    new ApiResult()
                    {
                        Code = System.Net.HttpStatusCode.InternalServerError,
                        Success = false,
                        Message = msg.Trim('|')
                    }
                );
            }
        }
    }
}

