using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.IServices.System;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.UI.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Permission")]
    public class SysRoleController : ControllerBase
    {
        private readonly ISysRoleService _sysRoleService;
        public SysRoleController(ISysRoleService sysRoleService)
        {
            _sysRoleService = sysRoleService;
        }

        [HttpGet]
        public IActionResult SysRoleByID(string roleID)
        {
            SysRole sysRole = _sysRoleService.GetSysRoleByID(roleID);
            if (sysRole!=null)
            {
                return Ok(sysRole);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetByPage")]
        public IActionResult SysRoleByPage(int page=1,int rows=20)
        {
            List<SysRole> sysRoles = _sysRoleService.GetSysRoleByPages(page, rows, out int count);
            return Ok(new { count, data = sysRoles });
        }

        [HttpPost]
        public IActionResult SysRoleAdd(string roleTitle)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysRoleService.AddSysRole(roleTitle, userID));
        }

        [HttpDelete]
        public IActionResult SysRoleDelete(List<string> roleIDs)
        {
            return Ok(_sysRoleService.DeleteSysRole(roleIDs));
        }

        [HttpPut]
        public IActionResult SysRoleUpdate([FromBody]SysRole sysRole)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysRoleService.UpdateSysRole(sysRole, userID));
        }

        [HttpPatch]
        public IActionResult SysRoleRightUpdate(string roleID,List<string> moduleIDs)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysRoleService.SysRoleRightUpdate(roleID, moduleIDs, userID));
        }
    }
}