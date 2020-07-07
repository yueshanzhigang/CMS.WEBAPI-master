using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.JWT
{
    public class Token
    {
        public string TokenContent { get; set; }

        public DateTime Expires { get; set; }

        public string BroadcastKey { get; set; }
    }
}
