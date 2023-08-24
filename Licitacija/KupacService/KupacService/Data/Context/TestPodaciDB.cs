using KupacService.Entities;
using KupacService.Entities.Enumeration;
using KupacService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Context
{
    /// <summary>
    /// Test podaci klasa
    /// </summary>
    public static class TestPodaciDB
    {
        /// <summary>
        /// Pripremanje podataka za bazu
        /// </summary>
        /// <param name="app"></param>
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope() ) 
            {
                SeedData(serviceScope.ServiceProvider.GetService<KupacDBContext>());
            }
        }

        /// <summary>
        /// Punjenje podacima
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(KupacDBContext context)
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



            if (!context.KontaktOsobe.Any())
            {
                Console.WriteLine("Punjenje podataka...");

                context.KontaktOsobe.AddRange(
                    new KontaktOsoba()
                    {
                        KontaktOsobaID = Guid.Parse("A1E4C8FD-7794-413F-A0DF-0CFD061BD377"),
                        Ime = "Ana",
                        Prezime = "Plavsic",
                        Funkcija = "Menadzer",
                        Telefon = "065824545"

                    },
                    new KontaktOsoba()
                    {
                        KontaktOsobaID = Guid.Parse("B1253021-4EFA-4CB2-9CA0-3E917A46C37D"),
                        Ime = "Marko",
                        Prezime = "Sajic",
                        Funkcija = "CEO",
                        Telefon = "064254584"
                    },
                    new KontaktOsoba()
                    {
                        KontaktOsobaID = Guid.Parse("624D1184-2C3B-4B8A-A760-95C174EA0B57"),
                        Ime = "Bojan",
                        Prezime = "Mihic",
                        Funkcija = "Investitor",
                        Telefon = "063214587"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Podaci već postoje.");
            }

            if (!context.BrojeviTabla.Any())
            {
                Console.WriteLine("Punjenje podataka...");

                context.BrojeviTabla.AddRange(
                    //new BrojTable()
                    //{
                    //    BrojTableID = Guid.Parse("ABD5B151-0751-4A54-8561-81406D942CEB"),
                    //    Broj = 1,
                    //    OvlascenoLiceID = Guid.Parse("9565F329-1987-4785-9DCF-1DAE7F65A7C8")
                    //},
                    //new BrojTable()
                    //{
                    //    BrojTableID = Guid.Parse("2AAB9A98-80F5-4E56-AB5F-52AD3B96E109"),
                    //    Broj = 2,
                    //    OvlascenoLiceID = Guid.Parse("2D5EB676-78D6-4D9D-941B-5123A5859BDF")
                    //},
                    //new BrojTable()
                    //{
                    //    BrojTableID = Guid.Parse("6120699F-F281-4026-B24C-15851902B5A2"),
                    //    Broj = 3,
                    //    OvlascenoLiceID = Guid.Parse("F972B9BA-4A1E-4D5D-A465-9CBEE245092B")
                    //}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Podaci već postoje.");
            }

            if (!context.Prioriteti.Any())
            {
                Console.WriteLine("Punjenje podataka...");

                context.Prioriteti.AddRange(
                    new Prioritet()
                    {
                        PrioritetIzbor = "Vlasnik sistema za navodnjavanje."
                    },
                    new Prioritet()
                    {
                        PrioritetIzbor = "Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup."
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Podaci već postoje.");
            }

            if (!context.OvlascenaLica.Any())
            {
                var BrojeviTablaMock = new List<BrojTable>
                {
                    new BrojTable {BrojTableID = Guid.Parse("ABD5B151-0751-4A54-8561-81406D942CEB"), Broj=1},
                    new BrojTable {BrojTableID = Guid.Parse("2AAB9A98-80F5-4E56-AB5F-52AD3B96E109"), Broj=2}

                };

                var KupciMock = new List<Kupac>
                {
                    new PravnoLice {KupacID=Guid.Parse("EF1623BF-7709-48B9-A3DC-1F4206CCF8D3"), TipKupca = "Pravno Lice", OstvarenaPovrsina = 50, ImaZabranu = false, Adresa = "Hajduk Veljka bb, Beograd ", BrojTelefona1="065874687", BrojTelefona2 = "06321458", Email = "kupac1@dot.net", BrojRacuna="123456", KontaktOsobaID = Guid.Parse("B1253021-4EFA-4CB2-9CA0-3E917A46C37D") },
                    new Kupac {KupacID=Guid.Parse("DFD83F67-8C37-4ED2-B198-13A8DD48598B"), TipKupca = "Fizicko Lice", OstvarenaPovrsina = 70, ImaZabranu = false, Adresa = "Filipa Višnjiča 12, Valjevo ", BrojTelefona1="061454785", BrojTelefona2 = "06745874", Email = "kupac2@dot.net", BrojRacuna="5555456" }
                };

                Console.WriteLine("Punjenje podataka...");
                context.OvlascenaLica.AddRange(
                    new SrpskiDrzavljanin()
                    {
                        OvlascenoLiceID = Guid.Parse("9565F329-1987-4785-9DCF-1DAE7F65A7C8"),
                        Ime = "Aleksandar",
                        Prezime = "Jakovljevic",
                        TipOvlascenogLica = "Srpski Drzavljanin",
                        Adresa = "Adresa 1",
                        JMBG = "1234567891012",
                        BrojeviTabla = BrojeviTablaMock,
                        Kupci = KupciMock
                    },
                   new StraniDrzavljanin()
                   {
                       OvlascenoLiceID = Guid.Parse("2D5EB676-78D6-4D9D-941B-5123A5859BDF"),
                       Ime = "Marc",
                       Prezime = "Tomphson",
                       TipOvlascenogLica = "Strani Drzavljanin",
                       Drzava = Drzava.Canada,
                       BrojPasosa = "22135416",
                       Kupci = KupciMock
                   },
                   new SrpskiDrzavljanin()
                   {
                       OvlascenoLiceID = Guid.Parse("B1253021-4EFA-4CB2-9CA0-3E917A46C37D"),
                       Ime = "Anja",
                       Prezime = "Mijic",
                       TipOvlascenogLica = "Srpski Drzavljanin",
                       Adresa = "Adresa 7",
                       JMBG = "1234567891012",
                       BrojeviTabla = BrojeviTablaMock,
                       Kupci = KupciMock
                   }
                );

                    context.SaveChanges();
            }

            if (!context.Kupci.Any())
            {
                Console.WriteLine("Punjenje podataka...");

                var OvlascenaLicaMock = new List<OvlascenoLice>
                {
                    new OvlascenoLice { OvlascenoLiceID = Guid.Parse("9565F329-1987-4785-9DCF-1DAE7F65A7C8"), TipOvlascenogLica = "Srpski Drzavljanin", Adresa = "Cvetna 21, Leskovac"},
                    new OvlascenoLice { OvlascenoLiceID = Guid.Parse("2D5EB676-78D6-4D9D-941B-5123A5859BDF"), TipOvlascenogLica = "Strani Drzavljanin", Adresa = "High Hill 22200, Boston", }
                };

                var PrioritetiMock = new List<Prioritet>
                {
                    new Prioritet {PrioritetIzbor ="Vlasnik zemljišta koje je najbliže zemljištu koje se daje u zakup."},
                    new Prioritet { PrioritetIzbor = "Poljoprivrednik koji je upisan u Registar." }

                };

                var UplateMock = new List<UplataDTO>
                {
                    new UplataDTO {UplataID=Guid.Parse("cdee41ca-5861-47a1-0453-08db12a84c85")},
                    new UplataDTO {UplataID=Guid.Parse("BA554025-2CA0-4392-AA2A-8D29EC2B99F5")}
                };



                context.Kupci.AddRange(
                   new PravnoLice
                   {
                     KupacID = Guid.Parse("EF1623BF-7709-48B9-A3DC-1F4206CCF8D3"),
                     Prioriteti = PrioritetiMock,
                     TipKupca = "Pravno Lice",
                     OstvarenaPovrsina = 199,
                     Uplate = UplateMock,
                     OvlascenaLica = OvlascenaLicaMock, 
                     ImaZabranu = false,
                     Adresa = "Adresa 1",
                     KontaktOsobaID = Guid.Parse("A1E4C8FD-7794-413F-A0DF-0CFD061BD377"),
                     MaticniBroj = "12345678",
                     Faks = "24561"
                   },                     
                   new FizickoLice
                   {
                        KupacID = Guid.Parse("DFD83F67-8C37-4ED2-B198-13A8DD48598B"),
                        Prioriteti = PrioritetiMock,
                        TipKupca = "Fizicko Lice",
                        OstvarenaPovrsina = 80,
                        Uplate = UplateMock,
                        OvlascenaLica = OvlascenaLicaMock,
                        ImaZabranu = false,
                        Adresa = "Adresa 1",
                        JMBG = "12345678",
                        Ime = "Vladana",
                        Prezime = "Ilic"
                   }
                );

                

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("Podaci već postoje.");
            }
        }
    }
}
