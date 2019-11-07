using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Repository;
using Hospital.Repository.Context;
using Hospital.Repository.implementation;
using Hospital.Service;
using Hospital.Service.implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Hospital.Api
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
            //Para la migracion
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            //Repository y Servicios
            services.AddTransient<IPacienteRepository,PacienteRepository>();
            services.AddTransient<IPacienteService, PacienteService>();

            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IConsultaService, ConsultaService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                    new Info
                                    {
                                        Title = SwaggerConfiguration.DocInfoTitle,
                                        Version = SwaggerConfiguration.DocInfoVersion,
                                        Description = SwaggerConfiguration.DocInfoDescription,
                                        Contact = contact
                                    }
                                    );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Todos");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
