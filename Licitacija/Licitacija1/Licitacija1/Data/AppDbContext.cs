using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licitacija1.Entities;

namespace Licitacija1.Data
{
    /// <summary>
    /// klasa AppDbContext
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// konstruktor AppDbContext        
        /// /// </summary>
        /// <param name="opt"></param>
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }
         
        public DbSet<LicitacijaModel> Licitacije { get; set; }
        public DbSet<DokumentModel> Dokumenti { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

        }
    }
}
