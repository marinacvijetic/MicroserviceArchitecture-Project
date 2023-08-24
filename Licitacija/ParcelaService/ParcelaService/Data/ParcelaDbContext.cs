using Microsoft.EntityFrameworkCore;
using ParcelaService.Models;
using ParcelaService.Models.Enums;
using System;

namespace ParcelaService.Data
{
    public class ParcelaDbContext : DbContext
    {
        public ParcelaDbContext(DbContextOptions<ParcelaDbContext> opt) : base(opt)
        {

        }

        /// <summary>
        /// Specifikacija propertija, odnosno tabela koje ce biti kreirane u bazi.
        /// </summary>
        public DbSet<Parcela> Parcele { get; set; }
        public DbSet<DeoParcele> DeloviParcele { get; set; }
        public DbSet<DozvoljeniRad> DozvoljeniRadovi { get; set; }
        public DbSet<KvalitetZemljista> KvalitetiZemljista { get; set; }
        public DbSet<ZasticenaZona> ZasticeneZone { get; set; }
    }
}
