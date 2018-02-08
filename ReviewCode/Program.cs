using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ReviewCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddSingleton<ILanguage, Language>())
                .UseStartup<Startup>()              //Istartup类型返回Microsoft.AspNetCore.Hosting.ConventionBasedStartup
                .UseStartup<MyStartUp>()          //IStartup类型返回MyStartup
            .UseIISIntegration()
                .Build();
    }
}
