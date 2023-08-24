﻿// <auto-generated />
using System;
using KupacService.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KupacService.Migrations
{
    [DbContext(typeof(KupacDBContext))]
    [Migration("20230220183951_AdditionalChange")]
    partial class AdditionalChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KupacService.Entities.BrojTable", b =>
                {
                    b.Property<Guid>("BrojTableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Broj")
                        .HasColumnType("int");

                    b.Property<Guid?>("OvlascenoLiceID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BrojTableID");

                    b.HasIndex("OvlascenoLiceID");

                    b.ToTable("BrojeviTabla");
                });

            modelBuilder.Entity("KupacService.Entities.KontaktOsoba", b =>
                {
                    b.Property<Guid>("KontaktOsobaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontaktOsobaID");

                    b.ToTable("KontaktOsobe");
                });

            modelBuilder.Entity("KupacService.Entities.Kupac", b =>
                {
                    b.Property<Guid>("KupacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumPocetkaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumPrestankaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<int>("DuzinaTrajanjaZabraneGodine")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ImaZabranu")
                        .HasColumnType("bit");

                    b.Property<int>("OstvarenaPovrsina")
                        .HasColumnType("int");

                    b.Property<string>("TipKupca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KupacID");

                    b.ToTable("Kupci");

                    b.HasDiscriminator<string>("TipKupca").HasValue("Kupac");
                });

            modelBuilder.Entity("KupacService.Entities.OvlascenoLice", b =>
                {
                    b.Property<Guid>("OvlascenoLiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipOvlascenogLica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OvlascenoLiceID");

                    b.HasIndex("KupacID");

                    b.ToTable("OvlascenaLica");

                    b.HasDiscriminator<string>("TipOvlascenogLica").HasValue("OvlascenoLice");
                });

            modelBuilder.Entity("KupacService.Entities.Prioritet", b =>
                {
                    b.Property<int>("PrioritetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrioritetIzbor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrioritetID");

                    b.HasIndex("KupacID");

                    b.ToTable("Prioriteti");
                });

            modelBuilder.Entity("KupacService.Models.UplataDTO", b =>
                {
                    b.Property<Guid>("UplataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UplataID");

                    b.HasIndex("KupacID");

                    b.ToTable("UplataDTO");
                });

            modelBuilder.Entity("KupacService.Entities.FizickoLice", b =>
                {
                    b.HasBaseType("KupacService.Entities.Kupac");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Fizicko Lice");
                });

            modelBuilder.Entity("KupacService.Entities.PravnoLice", b =>
                {
                    b.HasBaseType("KupacService.Entities.Kupac");

                    b.Property<string>("Faks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KontaktOsobaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaticniBroj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("KontaktOsobaID");

                    b.HasDiscriminator().HasValue("Pravno Lice");
                });

            modelBuilder.Entity("KupacService.Entities.SrpskiDrzavljanin", b =>
                {
                    b.HasBaseType("KupacService.Entities.OvlascenoLice");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Srpski Drzavljanin");
                });

            modelBuilder.Entity("KupacService.Entities.StraniDrzavljanin", b =>
                {
                    b.HasBaseType("KupacService.Entities.OvlascenoLice");

                    b.Property<string>("BrojPasosa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Drzava")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Strani Drzavljanin");
                });

            modelBuilder.Entity("KupacService.Entities.BrojTable", b =>
                {
                    b.HasOne("KupacService.Entities.OvlascenoLice", null)
                        .WithMany("BrojeviTabla")
                        .HasForeignKey("OvlascenoLiceID");
                });

            modelBuilder.Entity("KupacService.Entities.OvlascenoLice", b =>
                {
                    b.HasOne("KupacService.Entities.Kupac", null)
                        .WithMany("OvlascenaLica")
                        .HasForeignKey("KupacID");
                });

            modelBuilder.Entity("KupacService.Entities.Prioritet", b =>
                {
                    b.HasOne("KupacService.Entities.Kupac", null)
                        .WithMany("Prioriteti")
                        .HasForeignKey("KupacID");
                });

            modelBuilder.Entity("KupacService.Models.UplataDTO", b =>
                {
                    b.HasOne("KupacService.Entities.Kupac", "Kupac")
                        .WithMany("Uplate")
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("KupacService.Entities.PravnoLice", b =>
                {
                    b.HasOne("KupacService.Entities.KontaktOsoba", "KontaktOsoba")
                        .WithMany()
                        .HasForeignKey("KontaktOsobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KontaktOsoba");
                });

            modelBuilder.Entity("KupacService.Entities.Kupac", b =>
                {
                    b.Navigation("OvlascenaLica");

                    b.Navigation("Prioriteti");

                    b.Navigation("Uplate");
                });

            modelBuilder.Entity("KupacService.Entities.OvlascenoLice", b =>
                {
                    b.Navigation("BrojeviTabla");
                });
#pragma warning restore 612, 618
        }
    }
}
