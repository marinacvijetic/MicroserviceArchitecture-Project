using Dokument.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dokument.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<DokumentEntity> Dokumenti { get; set; }
        public DbSet<UgovorOZakupuEntity> Ugovori { get; set; }
        public DbSet<VerzijaDokumentaEntity> VerzijeDokumenata { get; set; }


    }
}
