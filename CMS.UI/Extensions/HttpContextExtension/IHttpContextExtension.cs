using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.UI.Extensions
{
    public interface IHttpContextExtension
    {
        string GetClientIP();
    }
}
