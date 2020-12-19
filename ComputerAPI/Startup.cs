using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Database;
using Repository.Interfaces;
using Repository.Repo;
using System.Data;

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
            services.AddScoped<IComputer, DBComputer>();
            services.AddScoped<IRam, DBRam>();
            services.AddScoped<IBrand, DBBrand>();
            services.AddScoped<ICountry, DBCountry>();
            services.AddScoped<IType, DBType>();
            services.AddScoped<IMemory, DBMemory>();
            services.AddScoped<ICPU, DBCPU>();
            services.AddScoped<IGraphicCard, DBGraphic>();
            services.AddScoped<IDetail, MockDetail>();
            services.AddScoped<IOrder, DBOrder>();
            services.AddScoped<IDB, SqlDB>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200/");
                                  });
            });
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
