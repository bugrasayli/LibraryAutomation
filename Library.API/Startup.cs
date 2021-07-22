using Library.Domain.IMapper;
using Library.Domain.IRepository;
using Library.Domain.IServices;
using Library.Domain.IValidation;
using Library.Domain.Mapper;
using Library.Domain.Service;
using Library.Domain.Validation;
using Library.Infrastructure;
using Library.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddScoped<IWriterValidation, WriterValidation>();

            services.AddScoped<IKindService, KindService>();
            services.AddScoped<IKindMapper, KindMapper>();
            services.AddScoped<IKindRepository, KindRepository>();
            services.AddScoped<IKindValidation, KindValidation>();
            
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressMapper, AddressMapper>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressValidation, AddressValidation>();

            services.AddScoped<IBookMapper, BookMapper>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookValidation, BookValidation>();
            
            services.AddScoped<ICostumerMapper, CostumerMapper>();
            services.AddScoped<ICostumerRepository, CostumerRepository>();
            services.AddScoped<ICostumerService, CostumerService>();
            services.AddScoped<ICostumerValidation, CostumerValidation>();

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
