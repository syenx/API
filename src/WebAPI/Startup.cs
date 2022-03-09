using EDM.RFLocal.Sistema.Monitor.Negocio.Recursos;
using EDM.RFLocal.Sistema.Monitor.Repositorio.Recursos;
using EDM.RFLocal.Sistema.Monitor.WebAPI.Recursos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace EDM.RFLocal.Sistema.Monitor.WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://ddvakjyp9cehd.cloudfront.net", "https://localhost:44387", "https://localhost:5001",
                                            "https://edm-monitorportal-dev.btgpactual.com");
                    });
            });

            services.AddLogging(logging => logging.AddAWSProvider());
            services.AddAutoMapper(typeof(PerfilMapeamento));
            services.AddControllers();
            //Aqui vão as outras injeções
            services.ConfigurarNegocio();
            services.ConfigurarRepositorio();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Monitor API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monitor API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
