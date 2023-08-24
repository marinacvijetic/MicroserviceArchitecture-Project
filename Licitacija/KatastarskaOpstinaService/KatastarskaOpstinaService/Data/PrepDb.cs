using KatastarskaOpstinaService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KatastarskaOpstinaService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KatastarskaOpstinaDbContext>());
            }
        }
        private static void SeedData(KatastarskaOpstinaDbContext context)
        {
            Console.WriteLine("---Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not tun migrations: {ex.Message}");
            }
            if (!context.StatutiOpstina.Any())
            {
                Console.WriteLine("--> Seeding data about StatutOpstine...");
                context.StatutiOpstina.AddRange(
                    new StatutOpstine() { StatutOpstineId= Guid.Parse("86050F87-D8E7-416B-8CBA-3B0C227B5618"), SadrzajStatuta= "Lorem Ipsum is simply dummy text.", DatumKreiranjaStatuta=DateTime.Now },
                    new StatutOpstine() { StatutOpstineId = Guid.Parse("080C0A64-73BE-488C-BD35-3EDF995B5D36"), SadrzajStatuta = "Lorem Ipsum is simply dummy text.", DatumKreiranjaStatuta = DateTime.Now },
                    new StatutOpstine() { StatutOpstineId = Guid.Parse("9DAD6C4B-AF57-4344-938B-ADF9A3CE93E9"), SadrzajStatuta = "Lorem Ipsum is simply dummy text.", DatumKreiranjaStatuta = DateTime.Now }
                 );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");

            if (!context.KatastarskeOpstine.Any())
            {
                Console.WriteLine("--> Seeding data about KatastarskaOpstina...");
                context.KatastarskeOpstine.AddRange(
                    new KatastarskaOpstina() { KatastarskaOpstinaId = Guid.Parse("18991A06-5A78-4853-B335-70B6E81C2672"), StatutOpstineId = Guid.Parse("86050F87-D8E7-416B-8CBA-3B0C227B5618"), NazivOpstine = "Novi Sad" },
                    new KatastarskaOpstina() { KatastarskaOpstinaId = Guid.Parse("786FC54F-16C6-4889-BF89-71A269B4E5E9"), StatutOpstineId = Guid.Parse("9DAD6C4B-AF57-4344-938B-ADF9A3CE93E9"), NazivOpstine = "Subotica" }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");
                        
        }
    }
}
