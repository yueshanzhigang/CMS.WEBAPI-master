using CMS.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.IRepository
{
    public interface ISysUserInfoRepository : IBaseRepository<SysUserInfo>
    {
    }

    public interface ISysRoleRepository : IBaseRepository<SysRole>
    {
    }

    public interface ISysModuleRepository : IBaseRepository<SysModule>
    {
    }

    public interface ISysRoleRightRepository : IBaseRepository<SysRoleRight>
    {
    }
}
