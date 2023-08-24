using KupacService.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KupacService.Data.Interfaces;
using KupacService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using KupacService.Helpers;
using System.IO;
using System.Reflection;
using KupacService.ServiceCall;
using KupacService.ServiceCalls;

namespace KupacService
{
    /// <summary>
    /// StartUp class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// StartUp Construktor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Interfejs
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<KupacDBContext>(opt =>
            //    opt.UseInMemoryDatabase("InMem"));

            services.AddDbContext<KupacDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("KupacServiceConnection")));

            services.AddScoped<IKupacRepository, KupacRepository>();
            services.AddScoped<IBrojTableRepository, BrojTableRepository>();
            services.AddScoped<IKontaktOsobaRepository, KontaktOsobaRepository>();
            services.AddScoped<IOvlascenoLiceRepository, OvlascenoLiceRepository>();
            services.AddScoped<IPrioritetRepository, PrioritetRepository>();

            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddHttpClient<IUplataService, UplataService>();
            services.AddOptions();
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddOptions();
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc("KupacServiceOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Kupac Service API",
                    Version = "1",
                    //Description = "Pomoću ovog API-ja mogu da se vrše sve CRUD operacije u okviru mikroservica Kupac.",
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Marina Cvijetic",
                    //    Email = "marinacvijetic2@gmail.com",
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "FTN licence",
                    //    Url = new Uri(Configuration["Links:FTN"])
                    //},
                    //TermsOfService = new Uri(Configuration["Links:TermsOfService"])
                });

                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                setupAction.IncludeXmlComments(xmlCommentsPath);
            });
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/KupacServiceOpenApiSpecification/swagger.json", "Kupac Service API");
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KupacService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            TestPodaciDB.PrepPopulation(app);
        }
    }
}
