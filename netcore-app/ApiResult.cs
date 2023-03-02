using System;
using System.Net;
using netcore_app.Enums;

namespace netcore_app
{
    public class ApiResult
    {
        private HttpStatusCode code;
        private object? data;
        private string? message;
        private bool success;

        /// <summary>
        /// 状态代码
        /// </summary>
        public HttpStatusCode Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object? Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }
    }
}

