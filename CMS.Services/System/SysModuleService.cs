using CMS.Models.System;
using Services;
using System;
using System.Collections.Generic;
using CMS.IServices.System;
using CMS.IRepository;
using System.Linq;
using CMS.Common.Enum;
using CMS.Common;
using CMS.Models.ViewModel.SystemViewModel;
using AutoMapper;

namespace CMS.Services.System
{
    public class SysModuleService: BaseService<SysModule>,ISysModuleService
    {
        private readonly ISysModuleRepository _sysModuleRepository;
        private readonly ISysRoleRightRepository _sysRoleRightRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly Message message = new Message(-1,"");
        private readonly ResponseConstant _responseConstant;
        private readonly IMapper _mapper;

        public SysModuleService(ISysModuleRepository sysModuleRepository, ISysRoleRightRepository sysRoleRightRepository,ISysRoleRepository sysRoleRepository,ResponseConstant responseConstant,IMapper mapper)
            :base(sysModuleRepository)
        {
            _sysModuleRepository = sysModuleRepository;
            _sysRoleRightRepository = sysRoleRightRepository;
            _sysRoleRepository = sysRoleRepository;
            _responseConstant = responseConstant;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取该用户所有授权api
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public IQueryable<SysModule> GetModulesByRoleID(string RoleID)
        {

            IQueryable<SysRoleRight> sysRoleRights = _sysRoleRightRepository.GetModels(x => x.RoleID == RoleID);
            IQueryable<SysModule> sysModules = _sysModuleRepository.GetModels(x => x.ModuleState == Convert.ToInt32(StateEnum.正常)).Join(sysRoleRights, a => a.ModuleID, b => b.ModuleID, (a, b) => a);
            return sysModules;
        }

        public List<SysModuleDto> GetSysModuleForTree(string roleID)
        {
            IQueryable<SysModule> sysModules = GetModulesByRoleID(roleID);
            List<SysModule> baseModule = sysModules.Where(x => x.ParentID == ""||x.ParentID == null).ToList();
            return SysModuleRecursion(sysModules, baseModule);
        }

        public List<SysModuleDto> SysModuleRecursion(IQueryable<SysModule> sysModules,List<SysModule> parentSysModules)
        {
            List<SysModuleDto> sysModuleDtos = new List<SysModuleDto>();
            foreach (var item in parentSysModules)
            {
                SysModuleDto sysModuleDto = _mapper.Map<SysModuleDto>(item);
                var list = sysModules.Where(x => x.ParentID == item.ModuleID).ToList();
                if (list.Count>0)
                {
                    sysModuleDto.children = SysModuleRecursion(sysModules, list);
                }
                sysModuleDtos.Add(sysModuleDto);
            }
            return sysModuleDtos;
        }

        public Message SysModuleAdd(SysModule sysModule)
        {
            var count = _sysModuleRepository.GetModels(x => x.ModuleTitle == sysModule.ModuleTitle).ToList().Count();
            if (count>0)
            {
                message.Msg = _responseConstant.existSameName;
            }
            else
            {
                sysModule.Sort = _sysModuleRepository.GetModels(x => x.ParentID.Equals(sysModule.ParentID)).ToList().Count() + 1;
                sysModule.ModuleState = Convert.ToInt32(StateEnum.正常);
                sysModule.ModuleID = Guid.NewGuid().ToString().ToUpper();
                _sysModuleRepository.Add(sysModule);
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
            return message;
        }

        public Message SysModuleDelete(int moduleID)
        {
            SysModule sysModule = _sysModuleRepository.GetModels(x => x.ModuleID.Equals(moduleID)).FirstOrDefault();
            if (sysModule != null)
            {


                _sysModuleRepository.Delete(sysModule);
                IQueryable<SysRoleRight> sysRoleRights = _sysRoleRightRepository.GetModels(x => x.ModuleID.Equals(moduleID));
                foreach (var roleRight in sysRoleRights)
                {
                    _sysRoleRightRepository.Delete(roleRight);
                }
            }
            else
            {
                message.Msg = _responseConstant.deleteFail;
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
            return message;
        }

        public Message SysModuleUpdate(SysModule sysModule)
        {
            int count = _sysModuleRepository.GetModels(x => x.ModuleTitle.Equals(sysModule.ModuleTitle) && x.ModuleID!=sysModule.ModuleID).ToList().Count();
            if (count>0)
            {
                message.Msg = _responseConstant.existSameName;
            }
            else
            {
                _sysModuleRepository.Update(sysModule);
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

    }
}
