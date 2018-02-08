using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewCode
{
    /// <summary>
    /// 继承字IStartup的启动类型，如果要在启动类型中注册中间件是需要注入相关服务
    /// 只能在构造函数中注入，原因在与继承自IStartup的类型和没有继承自IStartup的类型是不一样的，前者注册的
    /// IStartup类型就是自定义的类型，后者注册的是一个继承自ConvetionBasedStartup类型
    /// </summary>
    public class MyStartUp : IStartup
    {
        private readonly IConfiguration configuration;
        private readonly ILanguage language;
        public MyStartUp(IConfiguration configuration,ILanguage language)
        {
            this.configuration = configuration;
            this.language = language;
        }
        /// <summary>
        /// 配置中间件
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseStartupMiddleware();
            var fileds = app.GetType().GetField("_components", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly);
            return;
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello IStartup" + "\t" + language.LanguageType);
            });
        }
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns>服务提供器</returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
