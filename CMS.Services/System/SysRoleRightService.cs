using CMS.IRepository;
using CMS.IServices.System;
using CMS.Models.System;
using Services;

namespace CMS.Services.System
{
    public class SysRoleRightService:BaseService<SysRoleRight>,ISysRoleRightService
    {
        private readonly ISysRoleRightRepository _sysRoleRightRepository;
        public SysRoleRightService(ISysRoleRightRepository sysRoleRightRepository):base(sysRoleRightRepository)
        {
            _sysRoleRightRepository = sysRoleRightRepository;
        }
    }
}
