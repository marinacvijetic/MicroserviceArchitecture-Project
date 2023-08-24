using AutoMapper;
using Licitacija1.Auth;
using Licitacija1.Data;
using Licitacija1.SyncDataServices.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Licitacija1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration ,IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Console.WriteLine(" Using IN MEM DB");
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            Console.WriteLine(" Using SQL DB");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("LicitacijaConnection")));
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<ILicitacijaRepository, LicitacijaRepository>();
            services.AddScoped<ILicitacijaDokumentRepository, LicitacijaDokumentRepository>();
            services.AddHttpClient<IJavnoNadmetanjeDataClient, HttpJavnoNadmetanjeDataClient>();

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setupAction => 
            {
                setupAction.SwaggerDoc("LicitacijaOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Licitacija API",
                    Version = "1",
                    //Description = "Pomoću ovog API-ja mogu da se vrše sve CRUD operacije u okviru agregata Licitacije.",
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Nikola Jovanovic",
                    //    Email = "nikolajovanovic109@gmail.com",
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/LicitacijaOpenApiSpecification/swagger.json", "Licitacija API");
                });
            }
            else  // ukoliko se nalazimo u Production modu postavljamo defaulr poruku za greske koje su nastale na servisu
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PreparationDB.PreparationLicitacije(app);
        }
    }
}
