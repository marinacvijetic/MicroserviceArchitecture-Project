using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParcelaService.Models;
using ParcelaService.Models.Enums;
using System;
using System.Linq;

namespace ParcelaService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ParcelaDbContext>());
            }
        }
        /// <summary>
        /// Metoda koja omogucava populaciju podataka u bazu.
        /// </summary>
        /// <param name="context">Kontekst baze u koju skladistimo podatke.</param>
        private static void SeedData(ParcelaDbContext context)
        {
                Console.WriteLine("---Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not tun migrations: {ex.Message}");
                }
            if(!context.KvalitetiZemljista.Any())
            {
                Console.WriteLine("--> Seeding data about KvalitetZemljista...");
                context.KvalitetiZemljista.AddRange(
                    new KvalitetZemljista() { KvalitetZemljistaId = Guid.Parse("042CE551-0736-4831-968A-1DB455F0F804"), Opis = "Los kvalitet", OznakaKvaliteta = "LK" },
                    new KvalitetZemljista() { KvalitetZemljistaId = Guid.Parse("07DE8E84-22CF-4C15-B5F4-5883706B4EB7"), Opis = "Srednji kvalitet", OznakaKvaliteta = "SK" },
                    new KvalitetZemljista() { KvalitetZemljistaId = Guid.Parse("EFD82E12-F20D-4619-BA9B-9ACC8ED3F523"), Opis = "Dobar kvalitet", OznakaKvaliteta = "DK" }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");
            
            if (!context.ZasticeneZone.Any())
            {
                Console.WriteLine("--> Seeding data about ZasticeneZone...");
                context.ZasticeneZone.AddRange(
                    new ZasticenaZona() { ZasticenaZonaId = Guid.Parse("A86D8A0B-A6B9-4BAC-A7DB-B3DFCDE53BA7"), BrojZasticeneZone = 1 },
                    new ZasticenaZona() { ZasticenaZonaId = Guid.Parse("1B01EFB4-B549-4320-8681-64BED0B09E26"), BrojZasticeneZone = 2 },
                    new ZasticenaZona() { ZasticenaZonaId = Guid.Parse("0457902B-B26B-4C59-81B9-6E47FAD64A7B"), BrojZasticeneZone = 3 }
                    );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");

            if (!context.DozvoljeniRadovi.Any())
            {
                Console.WriteLine("--> Seeding data about DozvoljenRadovi...");
                context.DozvoljeniRadovi.AddRange(
                    new DozvoljeniRad() { DozvoljeniRadId=Guid.Parse("1218EA9C-BB2B-476E-85E0-8D52881EE352"), Opis= "Lorem ipsum dolor sit amet, consectetur adipiscing elit." , ZasticenaZonaId=Guid.Parse("A86D8A0B-A6B9-4BAC-A7DB-B3DFCDE53BA7")},
                    new DozvoljeniRad() { DozvoljeniRadId = Guid.Parse("6FB59DF6-16E1-4AB0-A93E-15D1EE3DDE26"), Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", ZasticenaZonaId = Guid.Parse("1B01EFB4-B549-4320-8681-64BED0B09E26") },
                    new DozvoljeniRad() { DozvoljeniRadId = Guid.Parse("9E9AA170-ADD5-4958-90C0-3F0564E22281"), Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", ZasticenaZonaId = Guid.Parse("0457902B-B26B-4C59-81B9-6E47FAD64A7B") }
                    );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");

            if (!context.Parcele.Any())
            {
                Console.WriteLine("--> Seeding data about Parcele...");
                context.Parcele.AddRange(
                    new Parcela() { ParcelaId = Guid.Parse("A068FC46-1152-4343-A7F0-202BC1B1E98F"), BrojParcele = "111", BrojListaNepokretnosti = "111", KatastarskaOpstinaId = Guid.Parse("18991A06-5A78-4853-B335-70B6E81C2672"), Kultura = Kultura.Pasnjaci, Klasa = Klasa.I, Obradivost = Obradivost.Obradivo, ZasticenaZonaId = Guid.Parse("A86D8A0B-A6B9-4BAC-A7DB-B3DFCDE53BA7"), OblikSvojine = OblikSvojine.PrivatnaSvojina },
                    new Parcela() { ParcelaId = Guid.Parse("87E7F3EE-DC69-4483-9E14-DE8D6C2ABDCB"), BrojParcele = "222", BrojListaNepokretnosti = "222", KatastarskaOpstinaId = Guid.Parse("786FC54F-16C6-4889-BF89-71A269B4E5E9"), Kultura = Kultura.Livade, Klasa = Klasa.I, Obradivost = Obradivost.Obradivo, ZasticenaZonaId = Guid.Parse("1B01EFB4-B549-4320-8681-64BED0B09E26"), OblikSvojine = OblikSvojine.DrzavnaSvojina }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");
            if (!context.DeloviParcele.Any())
            {
                Console.WriteLine("--> Seeding data about DeloviParcele...");
                context.DeloviParcele.AddRange(
                    new DeoParcele() { DeoParceleId = Guid.Parse("3C1D649A-3D5A-499F-9EC8-F1A7A19F23FC"), ParcelaId = Guid.Parse("A068FC46-1152-4343-A7F0-202BC1B1E98F"), RedniBrojDelaParcele = 1, PovrsinaDelaParcele = 300, KvalitetZemljistaId = Guid.Parse("042CE551-0736-4831-968A-1DB455F0F804") },
                    new DeoParcele() { DeoParceleId = Guid.Parse("50D4BDAF-212A-4C53-8C53-67BFD2A9D049"), ParcelaId = Guid.Parse("A068FC46-1152-4343-A7F0-202BC1B1E98F"), RedniBrojDelaParcele = 2, PovrsinaDelaParcele = 450, KvalitetZemljistaId = Guid.Parse("07DE8E84-22CF-4C15-B5F4-5883706B4EB7") }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is already loaded...");
        }
    }
}
