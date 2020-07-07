using CMS.Common;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.IServices.System
{
    public interface ISysModuleService : IBaseService<SysModule>
    {
        IQueryable<SysModule> GetModulesByRoleID(string RoleID);

        Message SysModuleAdd(SysModule sysModule);

        Message SysModuleUpdate(SysModule sysModule);

        Message SysModuleDelete(int moduleID);

        List<SysModuleDto> GetSysModuleForTree(string roleID);
    }
}
