using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.System
{
    [Table("SysRole")]
    public class SysRole:BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string RoleID { get; set; }

        [Column("RoleTitle")]
        [StringLength(32)]
        [Required]
        public string RoleTitle { get; set; }

        [Required]
        public int RoleState { get; set; }

        [Required]
        [StringLength(32)]
        public string Description { get; set; }

    }

}
