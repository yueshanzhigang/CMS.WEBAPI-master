using CMS.Common.Enum;
using CMS.IServices.System;
using CMS.Models.System;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.UI.JWT
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement()
        {
        }

        public List<SysModule> UsePermissionList { get; set; }
    }
}
