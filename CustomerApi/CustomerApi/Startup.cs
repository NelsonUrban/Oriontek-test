using AutoMapper;
using CustomerApi.BusinessLogic.Configurations.DepencyInjection;
using CustomerApi.Common.Configurations.DependencyInjection;
using CustomerApi.Configuration.Filters;
using CustomerApi.DataAccess.Configurations.DepencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CustomerApi
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
            services.AddCors(o => o.AddPolicy("EveryOne", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            }));
            services.AddControllers(opt =>
            {
                opt.EnableEndpointRouting = false;
                opt.ReturnHttpNotAcceptable = true;
                opt.Filters.Add(new HttpResponseExceptionFilter());

            }).AddNewtonsoftJson();
            services.AddHttpContextAccessor();
            services.RepositoriesConfiguration(Configuration);
            services.ServicesConfiguration();
            services.ConfigureGlobalizationService();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMapper, Mapper>();
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
            app.UseCors("EveryOne");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
