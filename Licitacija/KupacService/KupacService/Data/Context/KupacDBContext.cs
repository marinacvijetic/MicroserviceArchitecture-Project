using KupacService.Entities;
using KupacService.Entities.Enumeration;
using KupacService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KupacService.Data.Context
{
    /// <summary>
    /// DB Context 
    /// </summary>
    public class KupacDBContext : DbContext
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="option"></param>
        public KupacDBContext(DbContextOptions<KupacDBContext> option) : base(option) { }

        
        /// <summary>
        /// DB Set za prioritete
        /// </summary>
        public DbSet<Prioritet> Prioriteti { get; set; }

        /// <summary>
        /// DB ovlasceno lice
        /// </summary>
        public DbSet<OvlascenoLice> OvlascenaLica { get; set; }

        /// <summary>
        /// DB set kontakt osobe
        /// </summary>
        public DbSet<KontaktOsoba> KontaktOsobe { get; set; }

        /// <summary>
        /// DB set Kupci 
        /// </summary>
        public DbSet<Kupac> Kupci { get; set; }


        /// <summary>
        /// DB set brojevi table
        /// </summary>
        public DbSet<BrojTable> BrojeviTabla { get; set; }

        /// <summary>
        /// On model creating metoda
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UplataDTO>().HasNoKey();
            //modelBuilder.Entity<JavnoNadmetanjeDTO>().HasNoKey();
            modelBuilder.Entity<Kupac>().HasMany(x => x.Uplate)
              .WithOne(x => x.Kupac).HasForeignKey(x => x.KupacID);
            modelBuilder.Entity<PravnoLice>().HasMany(x => x.Prioriteti);
            modelBuilder.Entity<PravnoLice>().HasMany(x => x.Uplate);
            modelBuilder.Entity<PravnoLice>().HasOne(x => x.KontaktOsoba);

            modelBuilder.Entity<FizickoLice>().HasMany(x => x.Prioriteti);
            modelBuilder.Entity<FizickoLice>().HasMany(x => x.Uplate);

            modelBuilder.Entity<FizickoLice>()
                .HasBaseType<Kupac>()
                .HasDiscriminator(x => x.TipKupca)
                .HasValue<FizickoLice>("Fizicko Lice");

            modelBuilder.Entity<PravnoLice>()
                .HasBaseType<Kupac>()
                .HasDiscriminator(x => x.TipKupca)
                .HasValue<PravnoLice>("Pravno Lice");

            modelBuilder.Entity<SrpskiDrzavljanin>()
                .HasBaseType<OvlascenoLice>()
                .HasDiscriminator(x => x.TipOvlascenogLica)
                .HasValue<SrpskiDrzavljanin>("Srpski Drzavljanin");

            modelBuilder.Entity<StraniDrzavljanin>()
                .HasBaseType<OvlascenoLice>()
                .HasDiscriminator(x => x.TipOvlascenogLica)
                .HasValue<StraniDrzavljanin>("Strani Drzavljanin");




        }

        /// <summary>
        /// Konfiguracija kupca
        /// </summary>
        public class KupacConfig : IEntityTypeConfiguration<Kupac>
        {
            /// <summary>
            /// Konfiguracija metode
            /// </summary>
            /// <param name="builder"></param>
            public void Configure(EntityTypeBuilder<Kupac> builder)
            {
                builder.HasMany(x => x.JavnaNadmetanja).WithMany(x => x.Kupci)
                    .UsingEntity<KupacJavnoNadmetanje>(
                    r => r.HasOne(x => x.JavnoNadmetanje).WithMany().HasForeignKey(x => x.JavnoNadmetanjeID),
                    l => l.HasOne(x => x.Kupac).WithMany().HasForeignKey(x => x.KupacID));

                builder.HasMany(x => x.OvlascenaLica).WithMany(x => x.Kupci)
                    .UsingEntity<KupacOvlascenoLice>(
                    r => r.HasOne(x => x.OvlascenoLice).WithMany().HasForeignKey(x => x.OvlascenoLiceID),
                    l => l.HasOne(x => x.Kupac).WithMany().HasForeignKey(x => x.KupacID));

                
                    
            }
        }

    }
}
