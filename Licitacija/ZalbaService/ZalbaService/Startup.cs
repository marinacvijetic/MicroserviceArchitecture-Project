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
using ZalbaService.Auth;
using ZalbaService.Data;
using ZalbaService.Data.Context;

namespace ZalbaService
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            Console.WriteLine(" Using SQL DB");
            services.AddDbContext<ZalbaDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ZalbaConnection")));

            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<IZalbaRep, ZalbaRep>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc("ZalbaOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Zalba API",
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
                    setupAction.SwaggerEndpoint("/swagger/ZalbaOpenApiSpecification/swagger.json", "Zalba API");
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
