using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patronage.Application.FizzBuzz.Queries;
using Patronage.Application.Interfaces;
using Patronage.Infrastructure;
using Patronage.Infrastructure.Middlewares;
using Patronage.Infrastructure.Services;
using Patronage.Infrastucture;
using Swashbuckle.AspNetCore.Swagger;

namespace Patronage.WebApi
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
            //Services
            services.AddTransient<IFizzBuzzService, FizzBuzzService>();
            services.AddTransient<IMockIOService, MockIOService>();
            services.AddTransient<ILogger, LoggerService>();

            //MediatR
            services.AddMediatR(
                typeof(GetFizzBuzzQueryHandler).Assembly
                );

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Patronage API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patronage API V1");
            });
        }
    }
}
