using KatastarskaOpstinaService.Models;
using Microsoft.EntityFrameworkCore;

namespace KatastarskaOpstinaService.Data
{
    public class KatastarskaOpstinaDbContext : DbContext
    {
        public KatastarskaOpstinaDbContext(DbContextOptions<KatastarskaOpstinaDbContext> opt) : base(opt)
        {

        }

        public DbSet<KatastarskaOpstina> KatastarskeOpstine { get; set; }
        public DbSet<StatutOpstine> StatutiOpstina { get; set; }
    }
}
