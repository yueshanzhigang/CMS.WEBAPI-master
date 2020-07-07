using CMS.Common.Enum;
using CMS.IServices.System;
using CMS.Models.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CMS.UI.JWT
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly ISysModuleService _sysModuleService;
        public PermissionHandler(ISysModuleService sysModuleService)
        {
            _sysModuleService = sysModuleService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement  permissionRequirement)
        {
            if (context.User.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.Role))!=null)
            {
                var _roleID = context.User.Claims.First(m => m.Type.Equals(ClaimTypes.Role)).Value;

                var ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                //开发模式，超级管理员
                if (ASPNETCORE_ENVIRONMENT == "Development" && _roleID.ToUpper() == "1A06DB52-5C64-4F84-90CE-56710BA713D8")
                {
                    context.Succeed(permissionRequirement);
                }
                else
                {
                    if (!permissionRequirement.UsePermissionList.Any())
                    {
                        List<SysModule> sysModules = _sysModuleService.GetModulesByRoleID(_roleID).ToList();
                        permissionRequirement.UsePermissionList = sysModules;
                    }

                    var Request = (context.Resource as AuthorizationFilterContext).HttpContext.Request;
                    if (null != permissionRequirement.UsePermissionList && permissionRequirement.UsePermissionList.Any(m => m.Url.ToLower().Equals(Request.Path.Value.ToLower()) && m.Method.Equals(Enum.GetName(typeof(MethodEnum), Request.Method))))
                    {
                        context.Succeed(permissionRequirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
            }else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
