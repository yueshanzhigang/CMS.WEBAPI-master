using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Common
{
    public class ResponseConstant
    {
        #region 公共
        public string existSameName = "名称已存在！";

        public string addSuccess = "添加成功！";

        public string addFail = "添加失败！";

        public string deleteSuccess = "删除成功！";

        public string deleteFail = "删除失败！";

        public string deleteInputEmpty = "请选择要删除的内容！";

        public string checkFail = "查询失败！";

        public string updateSuccess = "修改成功！";

        public string updateFail = "修改失败！";

        public string authorizedSuccess = "授权成功！";

        public string authorizedFail = "授权失败！";

        public string requestFail = "请求失败！";

        #endregion

        #region 登录信息
        public string loginFailByInputError = "账号或密码输入错误！";

        public string loginFailByInputEmpty = "账号或密码不能为空！";

        public string loginSuccess = "登录成功！";

        public string loginFial = "登录失败！";
        #endregion

        #region 角色操作
        public string sysRoleInputEmpty = "角色名称不能为空！";

        public string SysRoleUsed = "{0} 角色已被使用,删除失败！";
        #endregion

        #region 系统用户
        public string sysUserNameInputEmput = "用户名不能为空！";
        public string sysUserAccountInputEmpty = "账号不能为空！";
        public string sysUserPasswordInputEmpty = "密码不能为空！";
        public string sysUserRoleInputEmpty = "角色不能为空！";
        public string sysUserNameExistSame = "用户名已存在！";
        public string sysUserAccountExistSame = "账号已存在！";
        public string sysUserDifPassword = "两次密码输入不一致！";
        #endregion
    }
}
