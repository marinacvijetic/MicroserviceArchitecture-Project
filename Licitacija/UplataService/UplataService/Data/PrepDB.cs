using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;

namespace UplataService.Data
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UplataDBContext>());
            }
        }

        /// <summary>
        /// Metoda koja omogućava populaciju podataka u bazu.
        /// </summary>
        /// <param name="context">Kontekst baze u koju skladištimo podatke.</param>
        private static void SeedData(UplataDBContext context)
        {
            Console.WriteLine("Applying migrations");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.Write("COuldnt run migrations : {ex.Message} ");
            }
            if (!context.Uplate.Any())
            {
                Console.WriteLine("Seeding data....");

                context.Uplate.AddRange(
                    new Uplata()
                    {
                        PozivNaBroj = "083755985357",
                        Iznos = 6899,
                        KupacID = Guid.Parse("8bab74c0-bbbf-4108-7a81-08db11d8b41b"),
                        SvrhaUplate = "Prijava na nadmetanje...",
                        Datum = DateTime.Parse("2020-09-13T09:00:00"),
                        JavnoNadmetanjeID = Guid.Parse("6DE0C4EE-8870-4649-A44B-921E5A7B2644")

                    },
                    new Uplata()
                    {
                        PozivNaBroj = "3567890",
                        Iznos = 34567,
                        KupacID = Guid.Parse("280e74e1-38d9-4291-7a82-08db11d8b41b"),
                        SvrhaUplate = "Prijava...",
                        Datum = DateTime.Parse("2020-07-09T09:00:00"),
                        JavnoNadmetanjeID = Guid.Parse("6DE0C4EE-8870-4649-A44B-921E5A7B2644")
                    }

                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We alredy have data");

            }
        }
    }
}
