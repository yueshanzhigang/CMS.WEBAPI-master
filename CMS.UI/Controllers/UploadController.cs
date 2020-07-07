using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.IServices;
using CMS.Models;
using CMS.UI.MultipartRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace CMS.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private IConfiguration Configuration;
        private IWebHostEnvironment env;
        private IUploadFileService _uploadFileService;

        public UploadController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IUploadFileService uploadFileService)
        {
            Configuration = configuration;
            env = webHostEnvironment;
            _uploadFileService = uploadFileService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UploadByIFormFile()
        {
            try
            {
                var user = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var files = Request.Form.Files;

                var filepath = Configuration.GetSection("UploadFilePath").GetSection("RelativePath").Value;
                if (string.IsNullOrEmpty(filepath))
                {
                    filepath = Configuration.GetSection("UploadFilePath").GetSection("ABsolutelyPath").Value;
                }
                else
                {
                    filepath = env.ContentRootPath + filepath;
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(filepath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                foreach (var formFile in files)
                {
                    UploadFile fileEmpty = new UploadFile();
                    fileEmpty.FileName = formFile.FileName;
                    fileEmpty.RealName = _uploadFileService.CreateFileRealName(formFile.FileName);
                    fileEmpty.CreateTime = DateTime.Now;
                    fileEmpty.Creator = user;
                    fileEmpty.FilePath = filepath;
                    if (formFile.Length > 0)
                    {
                        using (var stream = System.IO.File.Create(fileEmpty.FilePath + "\\" + fileEmpty.RealName))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    _uploadFileService.Add(fileEmpty);
                }
                if (_uploadFileService.SaveChanges())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadByMutipartRequest()
        {
            try
            {
                var user = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var filepath = Configuration.GetSection("UploadFilePath").GetSection("RelativePath").Value;
                if (string.IsNullOrEmpty(filepath))
                {
                    filepath = Configuration.GetSection("UploadFilePath").GetSection("ABsolutelyPath").Value;
                }
                else
                {
                    filepath = env.ContentRootPath + filepath;
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(filepath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                FormValueProvider formModel;
                formModel = await Request.StreamFiles(filepath,user, _uploadFileService);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}