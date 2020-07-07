using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.Common;
using CMS.IServices.System;
using CMS.Models.System;
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
    public class SysModuleController : ControllerBase
    {
        private readonly ISysModuleService _sysModuleService;
        public SysModuleController(ISysModuleService sysModuleService)
        {
            _sysModuleService = sysModuleService;
        }

        [HttpGet]
        public IActionResult SysModuleGetByID(int moduleID)
        {
            SysModule sysModule = _sysModuleService.GetModels(x => x.ModuleID.Equals(moduleID)).FirstOrDefault();
            if (sysModule != null) 
            {
                return Ok(sysModule);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult SysModuleAdd([FromBody]SysModule sysModule)
        {
            sysModule.CreateTime = DateTime.Now;
            sysModule.Creator = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            sysModule.UpdateTime = DateTime.Now;
            sysModule.UpdateBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_sysModuleService.SysModuleAdd(sysModule));
        }

        [HttpPut]
        public IActionResult SysModuleUpdate([FromBody]SysModule sysModule)
        {
            sysModule.UpdateBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            sysModule.UpdateTime = DateTime.Now;
            return Ok(_sysModuleService.SysModuleUpdate(sysModule));
        }

        [HttpGet]
        [Route("GetForTree")]
        public IActionResult SysModuleForTree()
        {
            string roleID = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(_sysModuleService.GetSysModuleForTree(roleID));
        }

        [HttpDelete]
        public IActionResult SysModuleDelete(int moduleID)
        {
            return Ok(_sysModuleService.SysModuleDelete(moduleID));
        }
    }
}