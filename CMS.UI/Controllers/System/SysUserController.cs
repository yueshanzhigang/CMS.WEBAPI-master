using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CMS.IServices.System;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Permission")]
    public class SysUserController : ControllerBase
    {
        private ISysUserInfoService _sysUserInfoService;
        private IMapper _mapper;
        public SysUserController(ISysUserInfoService sysUserInfoService, IMapper mapper)
        {
            _sysUserInfoService = sysUserInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSysUserInfoByID(string userID)
        {
            return Ok(_sysUserInfoService.SysUserInfoByID(userID));
        }

        [HttpGet]
        [Route("GetByPage")]
        public IActionResult GetSysUserByPage(int page=1,int rows=20)
        {
            var list = _sysUserInfoService.GetModels().OrderBy(x=>x.UserID).Skip((page - 1) * rows).Take(rows).ToList();
            List<SysLoginInfo> sysLoginInfos = _mapper.Map<List<SysUserInfo>, List<SysLoginInfo>>(list);
            var count = _sysUserInfoService.GetModels().Count();
            return Ok(new { count, data = sysLoginInfos });
        }

        [HttpPost]
        public IActionResult SysUserAdd([FromBody]SysLoginInfo sysLoginInfo)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysUserInfoService.SysUserAdd(sysLoginInfo, userID));
        }

        [HttpDelete]
        public IActionResult SysUserDelete(List<string> userIDs)
        {
            return Ok(_sysUserInfoService.SysUserDelete(userIDs));
        }

        [HttpPut]
        public IActionResult SysUserInfoUpdate([FromBody]SysLoginInfo sysLoginInfo)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysUserInfoService.SysUserInfoUpdate(sysLoginInfo, userID));
        }

        [HttpPut]
        [Route("UpdatePassword")]
        public IActionResult SysUserPasswordUpdate([FromBody]SysLoginInfo sysLoginInfo)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysUserInfoService.SysUserUpPassword(sysLoginInfo, userID));
        }
    }
}