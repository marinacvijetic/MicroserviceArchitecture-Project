using Korisnici.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korisnici.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<KorisnikEntity> Korisnici {get; set;}

      
       
    }
}
