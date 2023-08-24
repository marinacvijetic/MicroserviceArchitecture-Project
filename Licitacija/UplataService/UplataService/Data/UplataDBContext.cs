using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;

namespace UplataService.Data
{
    /// <summary>
    /// Specifikacija tabele koja će biti kreirana u bazi.
    /// </summary>
    public class UplataDBContext : DbContext 
    {
        public UplataDBContext(DbContextOptions<UplataDBContext> option) : base(option) { }

        public DbSet<Uplata> Uplate { get; set; }
    }
}
