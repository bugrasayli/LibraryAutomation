using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var scope = ConfigureContainer.container();
            using (scope.BeginLifetimeScope())
            {
                CreateHostBuilder(args).Build().Run();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
