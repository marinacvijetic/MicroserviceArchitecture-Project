using Dokument.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Dokument.Data
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

            //dokumenti
            if (!context.Dokumenti.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Dokumenti.AddRange(
                    new DokumentEntity()
                    {
                      
                        ZavodniBroj = "123",
                        Datum = DateTime.Parse("2020-11-17T09:00:00"),
                        DatumDonosenjaDokumenta = DateTime.Parse("2020-11-17T09:00:00"),
                        Sablon = "123456",
                        VerzijaDokumentaID=1,
                        StatusDokumenta = StatusDokumentaEnum.Otvoren


                    },
                    new DokumentEntity()
                    {
                       
                        ZavodniBroj = "12345",
                        Datum = DateTime.Parse("2020-11-17T09:00:00"),
                        DatumDonosenjaDokumenta = DateTime.Parse("2020-11-17T09:00:00"),
                        Sablon = "789123",        
                        VerzijaDokumentaID=2,
                        StatusDokumenta = StatusDokumentaEnum.Odbijen
                    }

                    );

                context.SaveChanges();
                
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
            //verzije
            if (!context.VerzijeDokumenata.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.VerzijeDokumenata.AddRange(
                    new VerzijaDokumentaEntity()
                    {
                       
                        DokumentID = 1,
                        Verzija = "1.1",
                        Revizija = " ",
                        Datum = DateTime.Parse("2020-11-17T09:00:00")

                    },
                    new VerzijaDokumentaEntity()
                    {

                        
                        DokumentID = 4,
                        Verzija = "2.2",
                        Revizija = " ",
                        Datum = DateTime.Parse("2020-11-17T09:00:00")
                    }

                    );

                context.SaveChanges();
                
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

            //ugovori

            if (!context.Ugovori.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Ugovori.AddRange(
                    new UgovorOZakupuEntity()
                    {
                        
                        JavnoNadmetanjeID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        DokumentID = 1,
                        TipGarancije = TipGarancijeEnum.Garancija_nekretninom,
                        KupacID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        RokDospeca = 2,
                        ZavodniBroj = " 345.12",
                        DatumZavodjenja= DateTime.Parse("2020-11-17T09:00:00"),
                        LicnostID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        RokZaVracanje= DateTime.Parse("2020-11-17T09:00:00"),
                        MestoPotpisivanja= "Novi Sad",
                        DatumPotpisivanja= DateTime.Parse("2020-11-17T09:00:00")

                    },
                    new UgovorOZakupuEntity()
                    {
                        
                        JavnoNadmetanjeID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        DokumentID = 4,
                        TipGarancije = TipGarancijeEnum.Zirantska,
                        KupacID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        RokDospeca = 10,
                        ZavodniBroj = " 35JKP",
                        DatumZavodjenja = DateTime.Parse("2020-11-17T09:00:00"),
                        LicnostID = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                        RokZaVracanje = DateTime.Parse("2020-11-17T09:00:00"),
                        MestoPotpisivanja = "Novi Sad",
                        DatumPotpisivanja = DateTime.Parse("2020-11-17T09:00:00")
                    }

                    );

                context.SaveChanges();
                
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

        }


    }
}
