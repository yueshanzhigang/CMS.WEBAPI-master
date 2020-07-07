using CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.IServices
{
    public interface IUploadFileService:IBaseService<UploadFile>
    {
        string CreateFileRealName(string filename);
    }
}
