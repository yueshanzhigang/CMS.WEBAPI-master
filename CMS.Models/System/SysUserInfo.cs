using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.System
{
    [Table("SysUserInfo")]
    public class SysUserInfo:BaseEntity
    {
        [Key]
        [Column("UserID")]
        [StringLength(36)]
        public string UserID { get; set; }

        [Column("Account")]
        [StringLength(32)]
        [Required]
        public string Account { get; set; }

        [Column("UserName")]
        [StringLength(32)]
        [Required]
        public string UserName { get; set; }

        [Column("Password")]
        [StringLength(64)]
        [Required]
        public string Password { get; set; }

        [Column("UserState")]
        [Required]
        public int UserState { get; set; }

        [Column("RoleID")]
        [Required]
        [StringLength(36)]
        public string RoleID { get; set; }

        [Column("LastLoginTime")]
        public DateTime LastLoginTime { get; set; }

        [Column("LastLoginIP")]
        [StringLength(32)]
        public string LastLoginIP { get; set; }
    }
}
