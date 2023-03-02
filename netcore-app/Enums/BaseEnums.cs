using System;
using System.ComponentModel;

namespace netcore_app.Enums
{
    public enum ResultStatusEnum
    {
        [Description("请求成功")]
        Success = 200,

        [Description("登录失效")]
        Unauthorized = 401,

        [Description("请求资源不存在")]
        NotFound = 404,

        [Description("未知异常")]
        Abnormal = 500,
    }
}

