using Library.Domain.IMapper;
using Library.Domain.IRepository;
using Library.Domain.IServices;
using Library.Domain.Mapper;
using Library.Domain.Service;
using Library.Infrastructure;
using Library.Infrastructure.Repository;
using Library.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Library.API
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
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            services.AddScoped<IWriterMapper, WriterMapper>();


            services.AddScoped<IKindService, KindService>();
            services.AddScoped<IKindMapper, KindMapper>();
            services.AddScoped<IKindRepository, KindRepository>();

            services.AddControllers();
            services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
