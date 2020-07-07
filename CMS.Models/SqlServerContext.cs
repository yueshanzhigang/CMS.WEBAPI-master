using CMS.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CMS.Models
{
    public class SqlServerContext:DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 重写连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // 从 appsetting.json 中获取配置信息
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    // 定义要使用的数据库
        //    //我是读取的文件内容，为了数据安全
        //    //optionsBuilder.UseSqlServer(DbConfig.InitConn(config.GetConnectionString("DefaultConnection_file"), config.GetConnectionString("DefaultConnection")));

        //    optionsBuilder.UseSqlServer(config.GetConnectionString("CMSConnection"));
        //}


        public DbSet<SysUserInfo> SysUserInfos { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysRoleRight> SysRoleRights { get; set; }
        public DbSet<SysModule> SysModules { get; set; }
    }
}
