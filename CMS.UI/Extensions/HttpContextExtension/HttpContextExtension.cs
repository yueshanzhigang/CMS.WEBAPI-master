using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.UI.Extensions
{
    public class HttpContextExtension:IHttpContextExtension
    {
        #region 申明属性

        private readonly IHttpContextAccessor HttpContextAccessor;
        private HttpContext Context => HttpContextAccessor.HttpContext;

        #endregion

        public HttpContextExtension(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        #region 获取客户端IP
        public string GetClientIP()
        {
            var ip = Context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = Context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
        #endregion
    }
}
