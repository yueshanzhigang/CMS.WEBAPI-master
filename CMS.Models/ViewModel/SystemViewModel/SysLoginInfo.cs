using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Models.ViewModel.SystemViewModel
{
    public class SysLoginInfo:BaseEntity
    {
        public string UserID { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        public string RePassword { get; set; }
        public string UserName { get; set; }
        public string VerifyCode { get; set; }
        public string RoleID { get; set; }
        public string LoginIP { get; set; }

        public int UserState { get; set; }

    }
}
