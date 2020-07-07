using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common;
using CMS.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.UI.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EnumController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStateEnum()
        {
            return Ok(typeof(StateEnum).EnumToJson());
        }

        [HttpGet]
        public IActionResult GetMethodEnum()
        {
            return Ok(typeof(MethodEnum).EnumToJson());
        }

        [HttpGet]
        public IActionResult GetSystemTypeEnum()
        {
            return Ok(typeof(SystemTypeEnum).EnumToJson());
        }
    }
}