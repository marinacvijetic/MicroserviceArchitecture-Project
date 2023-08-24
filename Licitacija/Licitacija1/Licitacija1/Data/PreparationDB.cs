using Licitacija1.DTOs;
using Licitacija1.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Data
{
    public static class PreparationDB
    {
        public static void PreparationLicitacije(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope() )
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        /// <summary>
        /// Filling the database with data
        /// </summary>
        private static void SeedData(AppDbContext context)
        {
           
                Console.WriteLine("Applying migrations");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.Write("COuldnt run migrations : {ex.Message} ");
                }
            
            if (!context.Licitacije.Any())
            {

                Console.WriteLine("Seeding Data...");
                context.Licitacije.AddRange(new LicitacijaModel()
                {
                    licitacijaID = Guid.Parse("3C5A441B-2ED4-4012-8377-6660B1994895"),

                    brojLicitacije = 2,

                    godina = 2020,

                    datumLicitacije = DateTime.Parse("2020-11-15T09:00:00"),

                    ogranicenjeLicitacije = 5,

                    korakCene = 5,

                    rokZaDostavuPrijava = DateTime.Parse("2020-11-15T09:00:00")
                },
                    new LicitacijaModel()
                    {
                        licitacijaID = Guid.Parse("6DE0C4EE-8870-4649-A44B-921E5A7B2644"),

                        brojLicitacije = 2,

                        godina = 2020,

                        datumLicitacije = DateTime.Parse("2020-11-15T09:00:00"),

                        ogranicenjeLicitacije = 5,

                        korakCene = 5,

                        rokZaDostavuPrijava = DateTime.Parse("2020-11-15T09:00:00")



                    })  ;
                context.SaveChanges();
                  
                
            }
            else
            {
                Console.WriteLine("We already have data");
            }

            

            if (!context.Dokumenti.Any())
            {
                Console.WriteLine("Seeding Data...");

                 context.Dokumenti.AddRange(new DokumentModel()
                {
                    licitacijaID = Guid.Parse("3C5A441B-2ED4-4012-8377-6660B1994895"),

                    dokumentID = Guid.Parse("1FCFB688-05CA-4304-8CD3-DF3F79B8AEB6"),

                    datum = DateTime.Parse("2020-11-15T09:00:00"),

                    NazivDokumenta = "Dokument1",

                    vrstaPodnosiocaDokumenta = "P"

                },
                    new DokumentModel()
                    {
                        licitacijaID = Guid.Parse("6DE0C4EE-8870-4649-A44B-921E5A7B2644"),

                        dokumentID = Guid.Parse("4F7C7ECD-49E7-4C39-8840-273954346524") ,

                        datum = DateTime.Parse("2020-11-15T09:00:00"),

                        NazivDokumenta = "Dokument2",

                        vrstaPodnosiocaDokumenta = "F"
                    });
                context.SaveChanges();


            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }


    }
}
