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

        public static string Port => Environment.GetEnvironmentVariable("PORT");

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseHerokuUrls()
                .UseStartup<Startup>();
    }
}
