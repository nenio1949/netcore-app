using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace netcore_app.Common.Filters
{
    public class ApiExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var errMsg = $"【异常类型】：{ex.GetType().Name} \r\n【异常信息】：{ex.Message} \r\n【堆栈调用】：{ex.StackTrace}";
            Console.WriteLine(errMsg);
            //LogHelper.Error(errMsg);

            context.Result = new ObjectResult(
                    new ApiResult()
                    {
                        Code = System.Net.HttpStatusCode.InternalServerError,
                        Success = false,
                        Message = ex.Message,
                    }
                );
        }
    }
}

