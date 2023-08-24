using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Data.Context;
using ZalbaService.Entities;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Data
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ZalbaDBContext>());
            }
        }

        /// <summary>
        /// Metoda koja omogućava populaciju podataka u bazu.
        /// </summary>
        /// <param name="context">Kontekst baze u koju skladištimo podatke.</param>

        private static void SeedData(ZalbaDBContext context)
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

            if (!context.Zalbe.Any())
            {
                Console.WriteLine("Seeding data....");

                context.Zalbe.AddRange(
                    new Zalba()
                    {
                        TipZalbe = TipZalbe.Zalba_na_odluku_o_davanju_na_koriscenje,
                        DatumPodnosenjaZalbe = DateTime.Parse("2020-11-15T09:00:00"),
                        KupacID = Guid.Parse("8C3D061E-945F-4481-A107-988986FE69D6"),
                        RazlogZalbe = "Nezadovoljstvo korisnika odlukom",
                        Obrazlozenje = "Korisnik nije zadovoljan zbog...",
                        DatumResenja = DateTime.Parse("2020-11-17T09:00:00"),
                        BrojResenja = "1205",
                        StatusZalbe = StatusZalbe.Usvojena,
                        BrojOdluke = "1340",
                        RadnjaNaOsnovuZalbe = RadnjaNaOsnovuZalbe.JN_ide_u_drugi_krug_sa_starim_uslovima
                    },
                    new Zalba()
                    {
                        TipZalbe = TipZalbe.Zalba_na_odluku_o_davanju_na_koriscenje,
                        DatumPodnosenjaZalbe = DateTime.Parse("2020-12-15T09:00:00"),
                        KupacID = Guid.Parse("6DE0C4EE-8870-4649-A44B-921E5A7B2644"),
                        RazlogZalbe = "Nezadovoljstvo korisnika nadmetanjem",
                        Obrazlozenje = "Korisnik nije zadovoljan zbog...",
                        DatumResenja = DateTime.Parse("2020-12-17T09:00:00"),
                        BrojResenja = "1255",
                        StatusZalbe = StatusZalbe.Odbijena,
                        BrojOdluke = "1344",
                        RadnjaNaOsnovuZalbe = RadnjaNaOsnovuZalbe.JN_ide_u_drugi_krug_sa_novim_uslovima
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
