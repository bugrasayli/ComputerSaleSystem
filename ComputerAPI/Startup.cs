using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Interfaces;
using Repository.Repo;

namespace ComputerAPI
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
            services.AddControllers();
            services.AddScoped<IComputer, MockComputer>();
            services.AddScoped<IRam, MockRam>();
            services.AddScoped<IBrand, MockBrand>();
            services.AddScoped<ICountry, MockCountry>();
            services.AddScoped<IType, MockType>();
            services.AddScoped<IMemory, MockMemory>();
            services.AddScoped<ICPU, MockCPU>();
            services.AddScoped<IGraphicCard, MockGraphicCard>();
            services.AddScoped<IDetail, MockDetail>();
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
