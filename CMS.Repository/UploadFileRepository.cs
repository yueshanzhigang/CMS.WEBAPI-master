using CMS.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Repository
{
    public class UploadFileRepository:BaseRepository<UploadFile>,IUploadFileRepository
    {
        public UploadFileRepository(SqlServerContext sqlServerContext):base(sqlServerContext)
        {

        }
    }
}
