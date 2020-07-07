using CMS.Common;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.IServices.System
{
    public interface ISysUserInfoService:IBaseService<SysUserInfo>
    {
        Message SysUserLogin(SysLoginInfo sysLoginInfo);

        SysLoginInfo SysUserInfoByID(string userID);

        Message SysUserAdd(SysLoginInfo sysLoginInfo, string creator);

        Message SysUserInfoUpdate(SysLoginInfo sysLoginInfo,string updateBy);

        Message SysUserDelete(List<string> userIDs);

        Message SysUserUpPassword(SysLoginInfo sysLoginInfo, string updateBy);
    }
}
