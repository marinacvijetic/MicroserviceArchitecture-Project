﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParcelaService.Data;

namespace ParcelaService.Migrations
{
    [DbContext(typeof(ParcelaDbContext))]
    partial class ParcelaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParcelaService.Models.DeoParcele", b =>
                {
                    b.Property<Guid>("DeoParceleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KvalitetZemljistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParcelaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PovrsinaDelaParcele")
                        .HasColumnType("int");

                    b.Property<int>("RedniBrojDelaParcele")
                        .HasColumnType("int");

                    b.HasKey("DeoParceleId");

                    b.HasIndex("KvalitetZemljistaId");

                    b.HasIndex("ParcelaId");

                    b.ToTable("DeloviParcele");
                });

            modelBuilder.Entity("ParcelaService.Models.DozvoljeniRad", b =>
                {
                    b.Property<Guid>("DozvoljeniRadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("ZasticenaZonaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DozvoljeniRadId");

                    b.HasIndex("ZasticenaZonaId");

                    b.ToTable("DozvoljeniRadovi");
                });

            modelBuilder.Entity("ParcelaService.Models.KvalitetZemljista", b =>
                {
                    b.Property<Guid>("KvalitetZemljistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OznakaKvaliteta")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("KvalitetZemljistaId");

                    b.ToTable("KvalitetiZemljista");
                });

            modelBuilder.Entity("ParcelaService.Models.Parcela", b =>
                {
                    b.Property<Guid>("ParcelaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojListaNepokretnosti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojParcele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KatastarskaOpstinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Klasa")
                        .HasColumnType("int");

                    b.Property<string>("KlasaStvarnoStanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Kultura")
                        .HasColumnType("int");

                    b.Property<string>("KulturaStvarnoStanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OblikSvojine")
                        .HasColumnType("int");

                    b.Property<int>("Obradivost")
                        .HasColumnType("int");

                    b.Property<string>("ObradivostStvarnoStanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Odvodnjavanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OdvodnjavanjeStvarnoStanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("ZasticenaZonaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZasticenaZonaStvarnoStanje")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ParcelaId");

                    b.HasIndex("ZasticenaZonaId");

                    b.ToTable("Parcele");
                });

            modelBuilder.Entity("ParcelaService.Models.ZasticenaZona", b =>
                {
                    b.Property<Guid>("ZasticenaZonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojZasticeneZone")
                        .HasColumnType("int");

                    b.HasKey("ZasticenaZonaId");

                    b.ToTable("ZasticeneZone");
                });

            modelBuilder.Entity("ParcelaService.Models.DeoParcele", b =>
                {
                    b.HasOne("ParcelaService.Models.KvalitetZemljista", "KvalitetZemljista")
                        .WithMany()
                        .HasForeignKey("KvalitetZemljistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParcelaService.Models.Parcela", "Parcela")
                        .WithMany("DeloviParcele")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParcelaService.Models.DozvoljeniRad", b =>
                {
                    b.HasOne("ParcelaService.Models.ZasticenaZona", "ZasticenaZona")
                        .WithMany("DozvoljeniRadovi")
                        .HasForeignKey("ZasticenaZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParcelaService.Models.Parcela", b =>
                {
                    b.HasOne("ParcelaService.Models.ZasticenaZona", "ZasticenaZona")
                        .WithMany()
                        .HasForeignKey("ZasticenaZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
