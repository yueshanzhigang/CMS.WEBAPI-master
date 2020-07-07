using System;
using System.Text;
using Autofac;
using AutoMapper;
using CMS.Models;
using CMS.Models.JWT;
using CMS.UI.AutoMapper;
using CMS.UI.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

namespace CMS.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //注册HttpContext在Controller以外的地方使用
            services.AddHttpContextAccessor();

            #region cors 跨域
            //添加cors 服务 配置跨域处理            
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
            #endregion

            #region 启用JWT认证 授权

            #region 读取配置
            services.Configure<JWTConfig>(Configuration.GetSection("JWT"));
            JWTConfig config = new JWTConfig();
            Configuration.GetSection("JWT").Bind(config);
            #endregion

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.IssuerSigningKey)),
                    ClockSkew = TimeSpan.FromMinutes(1)//设置偏差时间，默认五分钟
                };
            });

            //授权
            services.AddAuthorization(options => options.AddPolicy("Permission", policy => policy.Requirements.Add(new PermissionRequirement())));
            #endregion

            #region Swagger 配置
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "CMS API",
                    Description = "框架说明文档"
                });

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输)直接在下框中输入Bearer {token}(注意两者之间是一个空格)",
                    Name = "Authorization",//jwt默认参数名称
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
            });
            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(SystemProfile));
            #endregion
            //连接数据库
            services.AddDbContext<SqlServerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CMSConnection")));

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 134217728;//128M
            });

        }

        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new Extensions.AutofacModuleRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                    c.RoutePrefix = ""; //路径配置，设置为空，去launchSettings.json把launchUrl去掉
                });
            }

            app.UseCors("any");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),//监听连接，及时清理断开链接
                ReceiveBufferSize = 1 * 1024//缓存区
            });
            app.UseMiddleware<Extensions.WebSocketExtension.WebsocketHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
