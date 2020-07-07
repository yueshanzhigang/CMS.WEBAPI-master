using CMS.Common;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.IServices.System
{
    public interface ISysRoleService:IBaseService<SysRole>
    {
        Message AddSysRole(string roleTitle,string userID);

        Message UpdateSysRole(SysRole sysRole, string userID);

        Message DeleteSysRole(List<string> roleIDs);

        SysRole GetSysRoleByID(string roleID);

        List<SysRole> GetSysRoleByPages(int page,int rows,out int count);

        Message UpdateSysRoleState(string roleID, int roleState,string userID);

        Message SysRoleRightUpdate(string roleID, List<string> moduleIDs,string userID);
    }
}
