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

            //ע��HttpContext��Controller����ĵط�ʹ��
            services.AddHttpContextAccessor();

            #region cors ����
            //���cors ���� ���ÿ�����            
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //�����κ���Դ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//ָ������cookie
                });
            });
            #endregion

            #region ����JWT��֤ ��Ȩ

            #region ��ȡ����
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
                    ClockSkew = TimeSpan.FromMinutes(1)//����ƫ��ʱ�䣬Ĭ�������
                };
            });

            //��Ȩ
            services.AddAuthorization(options => options.AddPolicy("Permission", policy => policy.Requirements.Add(new PermissionRequirement())));
            #endregion

            #region Swagger ����
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "CMS API",
                    Description = "���˵���ĵ�"
                });

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ�����¿�������Bearer {token}(ע������֮����һ���ո�)",
                    Name = "Authorization",//jwtĬ�ϲ�������
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
            });
            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(SystemProfile));
            #endregion
            //�������ݿ�
            services.AddDbContext<SqlServerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CMSConnection")));

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 134217728;//128M
            });

        }

        // ע����Program.CreateHostBuilder�����Autofac���񹤳�
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
                    c.RoutePrefix = ""; //·�����ã�����Ϊ�գ�ȥlaunchSettings.json��launchUrlȥ��
                });
            }

            app.UseCors("any");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),//�������ӣ���ʱ����Ͽ�����
                ReceiveBufferSize = 1 * 1024//������
            });
            app.UseMiddleware<Extensions.WebSocketExtension.WebsocketHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
