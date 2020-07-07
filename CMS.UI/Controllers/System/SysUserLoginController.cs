using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common;
using CMS.IServices.System;
using CMS.Models.ViewModel.SystemViewModel;
using CMS.UI.Extensions;
using CMS.UI.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SysUserLoginController : ControllerBase
    {
        private readonly ISysUserInfoService _sysUserInfoService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextExtension _httpContextExtension;
        public SysUserLoginController(ISysUserInfoService sysUserInfoService, ITokenHelper tokenHelper, IHttpContextExtension httpContextExtension)
        {
            _sysUserInfoService = sysUserInfoService;
            _tokenHelper = tokenHelper;
            _httpContextExtension = httpContextExtension;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SysUserLogin(string Account,string Password)
        {
            SysLoginInfo sysLoginInfo = new SysLoginInfo();
            sysLoginInfo.Account = Account;
            sysLoginInfo.Password = Password;
            sysLoginInfo.LoginIP = _httpContextExtension.GetClientIP();
            Message message = _sysUserInfoService.SysUserLogin(sysLoginInfo);
            if (message.Code==0)
            {
                //生成token返回
                message.Data = _tokenHelper.CreateToken(message.Data);
            }
            return Ok(message);
        }
    }
}