using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ReviewCode
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class StartupMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStartup _startup;
        public StartupMiddleware(RequestDelegate next,IStartup startup)
        {
            _next = next;
            _startup = startup;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return httpContext.Response.WriteAsync(_startup.GetType().FullName);
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StartupMiddlewareExtensions
    {
        public static IApplicationBuilder UseStartupMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StartupMiddleware>();
        }
    }
}
