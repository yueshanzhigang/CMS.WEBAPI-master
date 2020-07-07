using CMS.IRepository;
using CMS.Models;
using CMS.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Repository
{
    public class SysUerInfoRepository:BaseRepository<SysUserInfo>,ISysUserInfoRepository
    {
        public SysUerInfoRepository(SqlServerContext sqlSeverContext):base(sqlSeverContext)
        {
        }
    }

    public class SysRoleRepository : BaseRepository<SysRole>, ISysRoleRepository
    {
        public SysRoleRepository(SqlServerContext sqlSeverContext) : base(sqlSeverContext)
        {
        }
    }

    public class SysModuleRepository : BaseRepository<SysModule>, ISysModuleRepository
    {
        public SysModuleRepository(SqlServerContext sqlSeverContext) : base(sqlSeverContext)
        {
        }
    }

    public class SysRoleRightRepository : BaseRepository<SysRoleRight>, ISysRoleRightRepository
    {
        public SysRoleRightRepository(SqlServerContext sqlSeverContext) : base(sqlSeverContext)
        {
        }
    }
}
