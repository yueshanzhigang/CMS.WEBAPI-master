using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.System
{
    [Table("SysRoleRight")]
    public class SysRoleRight
    {
        [Key]
        [Column("RoleRightID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleRightID { get; set; }

        [StringLength(36)]
        [Required]
        public string RoleID { get; set; }

        [Required]
        [StringLength(36)]
        public string ModuleID { get; set; }

        [Required]
        [StringLength(36)]
        public string Creator { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}
