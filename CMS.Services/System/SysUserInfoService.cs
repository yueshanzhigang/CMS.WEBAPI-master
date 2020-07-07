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
    public class SysUserInfoService:BaseService<SysUserInfo>,ISysUserInfoService
    {
        private readonly ResponseConstant _responseConstant;
        private readonly ISysUserInfoRepository _sysUserInfoRepository;
        private readonly IMapper _mapper;
        private readonly EncryptMd5 _encryptMd5;
        private readonly ISysRoleRightService _sysRoleRightService;
        private Message message = new Message();
        public SysUserInfoService(ISysUserInfoRepository sysUserInfoRepository,IMapper mapper, ResponseConstant responseConstant, EncryptMd5 encryptMd5, ISysRoleRightService sysRoleRightService) 
            :base(sysUserInfoRepository)
        {
            _sysUserInfoRepository = sysUserInfoRepository;
            _mapper = mapper;
            _responseConstant = responseConstant;
            _encryptMd5 = encryptMd5;
            _sysRoleRightService = sysRoleRightService;
            message = new Message(-1, _responseConstant.requestFail);
        }

        public Message SysUserAdd(SysLoginInfo sysLoginInfo, string creator)
        {
            try
            {
                if (string.IsNullOrEmpty(sysLoginInfo.UserName))
                {
                    message.Msg = _responseConstant.sysUserNameInputEmput;
                    return message;
                }
                else
                {
                    if (_sysUserInfoRepository.GetModels(x => x.UserName == sysLoginInfo.UserName).FirstOrDefault() != null)
                    {
                        message.Msg = _responseConstant.sysUserNameExistSame;
                        return message;
                    }
                }
                if (string.IsNullOrEmpty(sysLoginInfo.Account))
                {
                    message.Msg = _responseConstant.sysUserAccountInputEmpty;
                    return message;
                }
                else
                {
                    if (_sysUserInfoRepository.GetModels(x => x.Account == sysLoginInfo.Account).FirstOrDefault() != null)
                    {
                        message.Msg = _responseConstant.sysUserAccountExistSame;
                        return message;
                    }
                }
                if (string.IsNullOrEmpty(sysLoginInfo.Password))
                {
                    message.Msg = _responseConstant.sysUserPasswordInputEmpty;
                    return message;
                }
                var roleIDforGuid = sysLoginInfo.RoleID;
                if (string.IsNullOrEmpty(sysLoginInfo.RoleID.ToString()))
                {
                    message.Msg = _responseConstant.sysUserRoleInputEmpty;
                    return message;
                }
                else
                {
                    if (_sysRoleRightService.GetModels(x => x.RoleID == roleIDforGuid).FirstOrDefault() == null)
                    {
                        message.Msg = _responseConstant.addFail;
                        return message;
                    }
                }
                SysUserInfo sysUserInfo = new SysUserInfo();
                sysUserInfo.Account = sysLoginInfo.Account;
                sysUserInfo.UserName = sysLoginInfo.UserName;
                sysUserInfo.Password = _encryptMd5.EncryptByte(sysLoginInfo.Password);
                sysUserInfo.UserID = Guid.NewGuid().ToString().ToUpper();
                sysUserInfo.CreateTime = DateTime.Now;
                sysUserInfo.Creator = creator;
                sysUserInfo.UpdateBy = creator;
                sysUserInfo.UpdateTime = DateTime.Now;
                sysUserInfo.RoleID = roleIDforGuid;
                sysUserInfo.UserState = Convert.ToInt32(StateEnum.正常);
                _sysUserInfoRepository.Add(sysUserInfo);

                if (SaveChanges())
                {
                    message.Code = 0;
                    message.Msg = _responseConstant.addSuccess;
                }
                else
                {
                    message.Msg = _responseConstant.addFail;
                }
                return message;
            }
            catch (Exception ex)
            {
                return message;
            }
        }

        public Message SysUserDelete(List<string> userIDs)
        {
            try
            {
                message.Msg = _responseConstant.deleteFail;
                if (userIDs.Count > 0)
                {
                    foreach (var item in userIDs)
                    {
                        SysUserInfo sysUserInfo = _sysUserInfoRepository.GetModels(x => x.UserID.Equals(item)).FirstOrDefault();
                        if (sysUserInfo != null)
                        {
                            _sysUserInfoRepository.Delete(sysUserInfo);
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
            catch (Exception ex)
            {
                return message;
            }
        }

        public SysLoginInfo SysUserInfoByID(string userID)
        {
            SysUserInfo sysUserInfo = _sysUserInfoRepository.GetModels(x => x.UserID.Equals(userID)).FirstOrDefault();
            if (sysUserInfo!=null)
            {
                return _mapper.Map<SysLoginInfo>(sysUserInfo);
            }
            else
            {
                return new SysLoginInfo();
            }
        }

        public Message SysUserInfoUpdate(SysLoginInfo sysLoginInfo,string updateBy)
        {
            message.Msg = _responseConstant.updateFail;
            try
            {
                var oldSysUserInfo = _sysUserInfoRepository.GetModels(x => x.UserID == sysLoginInfo.UserID).FirstOrDefault();
                if (oldSysUserInfo!=null)
                {
                    oldSysUserInfo.UserName = sysLoginInfo.UserName;
                    oldSysUserInfo.Account = sysLoginInfo.Account;
                    oldSysUserInfo.UserState = sysLoginInfo.UserState;
                    oldSysUserInfo.UpdateBy = updateBy;
                    oldSysUserInfo.UpdateTime = sysLoginInfo.UpdateTime;
                    _sysUserInfoRepository.Update(oldSysUserInfo);
                    if (SaveChanges())
                    {
                        message.Code = 0;
                        message.Msg = _responseConstant.updateSuccess;
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                return message;
            }
        }

        public Message SysUserLogin(SysLoginInfo sysLoginInfo)
        {
            try
            {
                Message msg = new Message(-1, _responseConstant.loginFailByInputError);
                //不做验证码处理

                if (String.IsNullOrEmpty(sysLoginInfo.Account) || String.IsNullOrEmpty(sysLoginInfo.Password))
                {
                    msg.Msg = _responseConstant.loginFailByInputEmpty;
                }
                else
                {
                    var userList = _sysUserInfoRepository.GetModels(x => x.Account == sysLoginInfo.Account).ToList();
                    if (userList.Count != 0 && userList[0].Password == _encryptMd5.EncryptByte(sysLoginInfo.Password))
                    {
                        //修改登录信息
                        SysUserInfo sysUserInfo = userList[0];
                        sysUserInfo.LastLoginTime = DateTime.Now;
                        _sysUserInfoRepository.Update(sysUserInfo);
                        if (_sysUserInfoRepository.SaveChanges())
                        {
                            msg.Code = 0;
                            msg.Msg = _responseConstant.loginSuccess;
                            msg.Data = _mapper.Map<SysLoginInfo>(sysUserInfo);
                        }
                    }
                }
                return msg;
            }
            catch (Exception ex)
            {
                return message;
            }
        }

        public Message SysUserUpPassword(SysLoginInfo sysLoginInfo,string updateBy)
        {
            message.Msg = _responseConstant.updateFail;
            try
            {
                if (string.IsNullOrEmpty(sysLoginInfo.Password))
                {
                    message.Msg = _responseConstant.sysUserPasswordInputEmpty;
                    return message;
                }

                if (sysLoginInfo.RePassword!=sysLoginInfo.Password)
                {
                    message.Msg = _responseConstant.sysUserDifPassword;
                }
                else
                {
                    SysUserInfo sysUserInfo = _sysUserInfoRepository.GetModels(x => x.UserID == sysLoginInfo.UserID).FirstOrDefault();
                    if (sysUserInfo != null)
                    {
                        sysUserInfo.Password = _encryptMd5.EncryptByte(sysLoginInfo.Password);
                        sysUserInfo.UpdateBy = updateBy;
                        sysUserInfo.UpdateTime = sysLoginInfo.UpdateTime;
                        _sysUserInfoRepository.Update(sysUserInfo);
                        if (SaveChanges())
                        {
                            message.Code = 0;
                            message.Msg = _responseConstant.updateSuccess;
                        }
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                return message;
            }
        }
    }
}
