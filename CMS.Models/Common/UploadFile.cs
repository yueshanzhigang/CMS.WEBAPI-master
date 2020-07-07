using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    [Table("UploadFile")]
    public class UploadFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileID { get; set; }

        [Required]
        [StringLength(64)]
        public string FileName { get; set; }

        [Required]
        [StringLength(128)]
        public string RealName { get; set; }

        [Required]
        [StringLength(128)]
        public string FilePath { get; set; }

        [StringLength(32)]
        public string Remark { get; set; }

        [Required]
        [StringLength(36)]
        public string Creator { get; set; }

        [Required]
        public DateTime CreateTime {get;set;}
    }
}
