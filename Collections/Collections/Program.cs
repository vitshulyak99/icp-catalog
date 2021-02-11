using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseHerokuUrls()
                .UseStartup<Startup>();
    }
    
    public static class DevExtensions {
        public static string Port { get; } = Environment.GetEnvironmentVariable("PORT");

        public static IWebHostBuilder UseHerokuUrls(this IWebHostBuilder webHostBuilder)
        {
            if (!string.IsNullOrEmpty(Port))
            {
                webHostBuilder.UseUrls($"http://*:{Port}");
            }
            
            return webHostBuilder;
        }
    }
}
