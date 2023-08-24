using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data.Context
{
    public class ZalbaDBContext: DbContext
    {
        public ZalbaDBContext(DbContextOptions<ZalbaDBContext> option) : base(option) { }

        /// <summary>
        /// Specifikacija tabele koja će biti kreirana u bazi.
        /// </summary>
        public DbSet<Zalba> Zalbe { get; set; }
    }
}
