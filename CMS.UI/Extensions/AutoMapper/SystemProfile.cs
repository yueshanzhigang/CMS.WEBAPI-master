using AutoMapper;
using CMS.Common.Enum;
using CMS.Models.System;
using CMS.Models.ViewModel.SystemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.UI.AutoMapper
{
    public class SystemProfile: Profile
    {
        public SystemProfile()
        {
            //CreateMap<原对象, 目的对象>();
            CreateMap<SysUserInfo, SysLoginInfo>()
                .ForMember(dest => dest.LoginIP, opt => opt.MapFrom(src => src.LastLoginIP))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => "*****"));

            CreateMap<SysLoginInfo, SysUserInfo>()
                .ForMember(dest => dest.LastLoginIP, opt => opt.MapFrom(src => src.LoginIP));

            CreateMap<SysModule, SysModuleDto>();
        }
    }
}
