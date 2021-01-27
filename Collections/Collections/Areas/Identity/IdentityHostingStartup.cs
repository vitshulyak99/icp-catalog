using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Collections.Areas.Identity.IdentityHostingStartup))]
namespace Collections.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}