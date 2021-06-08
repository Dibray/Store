using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Store.Areas.Identity.IdentityHostingStartup))]
namespace Store.Areas.Identity
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