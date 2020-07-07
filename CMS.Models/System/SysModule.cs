using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.System
{
    [Table("SysModule")]
    public class SysModule:BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string ModuleID { get; set; }

        [StringLength(36)]
        public string ParentID { get; set; } = "unknow";

        [Required]
        [StringLength(32)]
        public string ModuleTitle { get; set; }

        [StringLength(32)]
        public string Url { get; set; }

        public int Method { get; set; }

        [Required]
        public int Sort { get; set; }

        [Required]
        public int ModuleState { get; set; }

        [StringLength(32)]
        public string Description { get; set; }
    }
}
