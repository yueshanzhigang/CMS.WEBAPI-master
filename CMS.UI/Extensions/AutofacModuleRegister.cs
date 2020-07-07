using Autofac;
using CMS.Common;
using CMS.UI.JWT;
using log4net;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CMS.UI.Extensions
{
    public class AutofacModuleRegister: Autofac.Module
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AutofacModuleRegister));
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;


            #region 带有接口层的服务注入

            var servicesDllFile = Path.Combine(basePath, "CMS.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "CMS.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                log.Error(msg);
                throw new Exception(msg);
            }

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency();
                      //.EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();

            #endregion

            #region 没有接口层的服务层注入

            //因为没有接口层，所以不能实现解耦，只能用 Load 方法。
            //注意如果使用没有接口的服务，并想对其使用 AOP 拦截，就必须设置为虚方法
            //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region 没有接口的单独类，启用class代理拦截

            //只能注入该类中的虚方法，且必须是public
            //这里仅仅是一个单独类无接口测试，不用过多追问
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
            //    .EnableClassInterceptors();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ResponseConstant)))
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(EncryptMd5)))
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CMSConstant))).SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AESHelper))).SingleInstance();
            #endregion

            #region 单独注册一个含有接口的类，启用interface代理拦截

            //不用虚方法
            //builder.RegisterType<AopService>().As<IAopService>()
            //   .AsImplementedInterfaces()
            //   .EnableInterfaceInterceptors()
            //   .InterceptedBy(typeof(BlogCacheAOP));

            builder.RegisterType<TokenHelper>().As<ITokenHelper>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<HttpContextExtension>().As<IHttpContextExtension>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<PermissionHandler>().As<IAuthorizationHandler>().AsImplementedInterfaces().SingleInstance();


            #endregion

        }
    }
}
