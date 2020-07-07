using CMS.IRepository;
using CMS.IServices;
using CMS.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CMS.Services
{
    public class UploadFileService:BaseService<UploadFile>,IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;
        public UploadFileService(IUploadFileRepository uploadFileRepository):base(uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public string CreateFileRealName(string filename)
        {
            var uploadFile = _uploadFileRepository.GetModels(x => x.RealName == filename).FirstOrDefault();
            if (uploadFile==null)
            {
                return filename;
            }
            else
            {
                var realName = string.Empty;
                int i = 0;
                do
                {
                    i++;
                    realName = Path.GetFileNameWithoutExtension(filename) + "(" + i + ")" + Path.GetExtension(filename);
                    uploadFile = _uploadFileRepository.GetModels(x => x.RealName == realName).FirstOrDefault();
                }
                while (uploadFile == null);
                return realName;
            }
        }
    }
}
