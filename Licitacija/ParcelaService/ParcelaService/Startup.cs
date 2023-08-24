using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ParcelaService.Auth;
using ParcelaService.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ParcelaService
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dodavanje konekcije na bazu.
            Console.WriteLine("--> Using sqlserv db");
            services.AddDbContext<ParcelaDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ParcelaConnection")));
                                    
            //dodavanje scopova.
            services.AddScoped<IDeoParceleRepo,DeoParceleRepo>();
            services.AddScoped<IDozvoljeniRadRepo,DozvoljeniRadRepo>();  
            services.AddScoped<IKvalitetZemljistaRepo,KvalitetZemljistaRepo>();
            services.AddScoped<IZasticenaZonaRepo, ZasticenaZonaRepo>();
            services.AddScoped<IParcelaRepo, ParcelaRepo>();
            services.AddScoped<IAuthHelper, AuthHelper>();

            //ukljucivanje automapera u projekat.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddOptions();

            //podesavanje kontrolera
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            //pdesavanje swaggera i dokumenta za kreiranje dokumentacije.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParcelaService", Version = "v1" });
                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                c.IncludeXmlComments(xmlCommentsPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else //Ukoliko se nalazimo u Production modu postavljamo default poruku za greške koje nastaju na servisu.
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Došlo je do neočekivane greške. Molimo pokušajte kasnije.");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Poziva se metoda za populaciju odnosno punjenje baze podataka.
            PrepDb.PrepPopulation(app);
        }
    }
}
