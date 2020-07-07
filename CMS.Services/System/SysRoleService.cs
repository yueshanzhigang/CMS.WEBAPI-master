using AutoMapper;
using CMS.Common;
using CMS.Common.Enum;
using CMS.IRepository;
using CMS.IServices.System;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Services.System
{
    public class SysRoleService:BaseService<SysRole>,ISysRoleService
    {
        private Message message = new Message(-1, "");
        private readonly ResponseConstant _responseConstant;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysUserInfoService _sysUserInfoService;
        private readonly IMapper _mapper;
        private readonly ISysModuleService _sysModuleService;
        private readonly ISysRoleRightService _sysRoleRightService;
        public SysRoleService(ISysRoleRepository sysRoleRepository,ISysUserInfoService sysUserInfoService,
            IMapper mapper, ISysModuleService sysModuleService, ISysRoleRightService sysRoleRightService, 
            ResponseConstant responseConstant) 
            :base(sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
            _sysUserInfoService = sysUserInfoService;
            _mapper = mapper;
            _sysModuleService = sysModuleService;
            _sysRoleRightService = sysRoleRightService;
            _responseConstant = responseConstant;
        }

        public Message AddSysRole(string roleTitle, string userID)
        {
            if (string.IsNullOrEmpty(roleTitle))
            {
                message.Msg = _responseConstant.sysRoleInputEmpty;
            }
            else
            {
                if (_sysRoleRepository.GetModels().ToList().Any(x => x.RoleTitle == roleTitle))
                {
                    message.Msg = _responseConstant.existSameName;
                }
                else
                {
                    SysRole sysRole = new SysRole();
                    sysRole.RoleID = Guid.NewGuid().ToString().ToUpper(); ;
                    sysRole.RoleState = Convert.ToInt32(StateEnum.正常);
                    sysRole.RoleTitle = roleTitle.Trim();
                    sysRole.Creator = userID;
                    sysRole.CreateTime = DateTime.Now;
                    sysRole.UpdateBy = userID;
                    sysRole.UpdateTime = DateTime.Now;
                    _sysRoleRepository.Add(sysRole);
                    if (SaveChanges())
                    {
                        message.Code = 0;
                        message.Msg = _responseConstant.addSuccess;
                    }
                    else
                    {
                        message.Msg = _responseConstant.addFail;
                    }
                }
            }
            return message;
        }

        public Message DeleteSysRole(List<string> roleIDs)
        {
            if (roleIDs.Count==0)
            {
                message.Msg = _responseConstant.deleteInputEmpty;
            }
            else
            {
                foreach (var item in roleIDs)
                {
                    SysRole sysRole = _sysRoleRepository.GetModels(x => x.RoleID.Equals(item)).FirstOrDefault();
                    if (_sysUserInfoService.GetModels(x => x.RoleID.Equals(item)).ToList().Count()>0)
                    {
                        StringBuilder str = new StringBuilder();
                        str.AppendFormat(_responseConstant.SysRoleUsed,ToString(), sysRole.RoleTitle);
                        message.Msg = str.ToString();
                        return message;
                    }
                    else if (sysRole!=null)
                    {
                        _sysRoleRepository.Delete(sysRole);
                    }
                    else
                    {
                        message.Msg = _responseConstant.deleteFail;
                        return message;
                    }
                }
                if (SaveChanges())
                {
                    message.Code = 0;
                    message.Msg = _responseConstant.deleteSuccess;
                }
                else
                {
                    message.Msg = _responseConstant.deleteFail;
                }
            }
            return message;
        }

        public SysRole GetSysRoleByID(string roleID)
        {
            return _sysRoleRepository.GetModels(x => x.RoleID.Equals(roleID)).FirstOrDefault();
        }

        public Message UpdateSysRole(SysRole sysRoleUpdate, string userID)
        {
            if (_sysRoleRepository.GetModels(x=>x.RoleTitle == sysRoleUpdate.RoleTitle && sysRoleUpdate.RoleID != x.RoleID).ToList().Count>0)
            {
                message.Msg = _responseConstant.existSameName;
            }
            else
            {
                SysRole sysRole = _sysRoleRepository.GetModels(x => x.RoleID.Equals(sysRoleUpdate.RoleID)).FirstOrDefault();
                sysRole.RoleTitle = sysRoleUpdate.RoleTitle;
                sysRole.UpdateBy = userID;
                sysRole.UpdateTime = DateTime.Now;
                _sysRoleRepository.Update(sysRole);
                if (SaveChanges())
                {
                    message.Code = 0;
                    message.Msg = _responseConstant.updateSuccess;
                }
                else
                {
                    message.Msg = _responseConstant.updateFail;
                }
            }
            return message;
        }

        public List<SysRole> GetSysRoleByPages(int page, int rows, out int count)
        {
            List<SysRole> sysRoles = _sysRoleRepository.GetModels().ToList();
            count = sysRoles.Count();
            sysRoles = sysRoles.OrderBy(x=>x.RoleID).Skip((page - 1) * rows).Take(rows).ToList();
            return sysRoles;
        }

        public Message UpdateSysRoleState(string roleID, int roleState,string userID)
        {
            SysRole sysRole = _sysRoleRepository.GetModels(x => x.RoleID.Equals(roleID)).FirstOrDefault();
            sysRole.RoleState = roleState;
            sysRole.UpdateBy = userID;
            sysRole.UpdateTime = DateTime.Now;
            _sysRoleRepository.Update(sysRole);
            if (SaveChanges())
            {
                message.Code = 0;
                message.Msg = _responseConstant.updateSuccess;
            }
            else
            {
                message.Msg = _responseConstant.updateFail;
            }
            return message;
        }

        public Message SysRoleRightUpdate(string roleID,List<string> moduleIDs,string userID)
        {
            message.Msg = _responseConstant.authorizedFail;
            if (moduleIDs.Count>0)
            {
                var oldSysModules = _sysRoleRightService.GetModels(x => x.RoleID == roleID).ToList();
                List<string> oldModuleIDs = oldSysModules.Select(x => x.ModuleID).ToList();
                List<string> deleteIDs = oldModuleIDs.Except(moduleIDs).ToList();
                foreach (var item in deleteIDs)
                {//删除去掉的
                    _sysRoleRightService.Delete(oldSysModules.FirstOrDefault(x => x.ModuleID == item));
                }

                List<string> addIDS = moduleIDs.Except(oldModuleIDs).ToList();
                var sysModules = _sysModuleService.GetModels(x => x.ModuleState == Convert.ToInt32(StateEnum.正常)).ToList();
                foreach (var item in addIDS)
                {
                    var addModule = sysModules.Where(x => x.ModuleID == item).FirstOrDefault();
                    if (addModule != null)
                    {
                        SysRoleRight sysRoleRight = new SysRoleRight();
                        sysRoleRight.ModuleID = addModule.ModuleID;
                        sysRoleRight.RoleID = roleID;
                        sysRoleRight.Creator = userID;
                        sysRoleRight.CreateTime = DateTime.Now;
                        _sysRoleRightService.Add(sysRoleRight);
                    }
                }
                if (SaveChanges())
                {
                    message.Code = 0;
                    message.Msg = _responseConstant.authorizedSuccess;
                }
            }
            return message;
        }
    }
}
