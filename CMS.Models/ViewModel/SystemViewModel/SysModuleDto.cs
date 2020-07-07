using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models.ViewModel.SystemViewModel
{
    public class SysModuleDto
    {
        public string ModuleID { get; set; }

        public string ParentID { get; set; }

        public string ModuleTitle { get; set; }

        public string Url { get; set; }

        public int Method { get; set; }

        public int Sort { get; set; }

        public int ModuleState { get; set; }

        public List<SysModuleDto> children { get; set; }//子菜单
    }
}
