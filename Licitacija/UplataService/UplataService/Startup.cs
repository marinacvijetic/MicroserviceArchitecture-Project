using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UplataService.Auth;
using UplataService.Data;

namespace UplataService
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            Console.WriteLine(" Using SQL DB");
            services.AddDbContext<UplataDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UplataConnection")));

            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<IUplataRep, UplataRep>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc("UplataOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Uplata API",
                    Version = "1",
                    //Description = "Pomoću ovog API-ja mogu da se vrše sve CRUD operacije u okviru agregata Zalba.",
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Katarina Zoric",
                    //    Email = "zorickatarina02@gmail.com",
                    //    Url = new Uri(Configuration["Links:FTN"])
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "FTN licence",
                    //    Url = new Uri(Configuration["Links:FTN"])
                    //},
                    //TermsOfService = new Uri(Configuration["Links:TermsOfService"])
                });

                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                setupAction.IncludeXmlComments(xmlCommentsPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/UplataOpenApiSpecification/swagger.json", "Uplata API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepPopulation(app);
        }
    }
}
