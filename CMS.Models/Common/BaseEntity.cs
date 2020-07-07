using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models
{
    public class BaseEntity
    {
        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
