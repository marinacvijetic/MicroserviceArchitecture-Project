using Korisnici.Auth;
using Korisnici.Data;
using Korisnici.Data.IRepo;
using Korisnici.Data.Repo;
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Korisnici
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine(" Using SQL DB");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("KorisnikConnection")));

            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IKorisnikRepo, KorisnikRepo>();
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            services.AddControllers();
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc("KorisnikOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Korisnik API",
                    Version = "1",
                    //Description = "Pomoću ovog API-ja mogu da se vrše sve CRUD operacije u okviru agregata Korisnik.",
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Ana Zivkucin",
                    //    Email = "zivkucinana@gmail.com",
                    //    Url = new Uri(Configuration["Links:FTN"])
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/KorisnikOpenApiSpecification/swagger.json", "Korisnik API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.prepPopulation(app);
        }
    }
}
