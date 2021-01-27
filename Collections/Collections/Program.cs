using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Collections.General;

namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static string Port => Environment.GetEnvironmentVariable("PORT");

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseHerokuUrls()
                .UseStartup<Startup>();
    }

    public static class WebHostBuilderExtension
    {
        public static IWebHostBuilder UseHerokuUrls(this IWebHostBuilder webHostBuilder) 
            => Develop.IsDeploy ? webHostBuilder.UseUrls($"http://*:{Program.Port}") : webHostBuilder;
    }
}
