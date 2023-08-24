using Korisnici.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Korisnici.Data
{
    public class PrepDb
    {
        public static void prepPopulation(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
               
            }


        }

        private static void SeedData(AppDbContext context)
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


            if (!context.Korisnici.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Korisnici.AddRange(
                    new KorisnikEntity()
                    {
                  
                        Ime = "Ana",
                        Prezime = "Zivkucin",
                        KorisnickoIme = "zivkucinana",
                        Lozinka = "ana123",
                        TipKorisnika = TipKorisnikaEnum.Tehnicki_sekretar
                    },
                    new KorisnikEntity()
                    {
                        
                        Ime = "Katarina",
                        Prezime = "Zoric",
                        KorisnickoIme = "zorickatarina",
                        Lozinka = "katarina123",
                        TipKorisnika = TipKorisnikaEnum.Menadzer
                    }

                    );
                context.SaveChanges();
     ; 
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
