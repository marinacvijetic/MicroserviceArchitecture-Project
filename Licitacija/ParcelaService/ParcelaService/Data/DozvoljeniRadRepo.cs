using Microsoft.EntityFrameworkCore;
using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class DozvoljeniRadRepo : IDozvoljeniRadRepo
    {
        private readonly ParcelaDbContext _context;
        public DozvoljeniRadRepo(ParcelaDbContext context)
        {
            _context = context;
        }
        public void Create(DozvoljeniRad dozvoljeniRad)
        {
            if (dozvoljeniRad == null) throw new ArgumentNullException(nameof(dozvoljeniRad));

            _context.DozvoljeniRadovi.Add(dozvoljeniRad);
        }

        public void Delete(Guid dozvoljeniRadId)
        {
            var rad = GetById(dozvoljeniRadId);
            _context.Remove(rad);

        }

        public IEnumerable<DozvoljeniRad> GetAll()
        {
            return _context.DozvoljeniRadovi.ToList();
        }

        public DozvoljeniRad GetById(Guid dozvoljeniRadId)
        {
            return _context.DozvoljeniRadovi.FirstOrDefault(p => p.DozvoljeniRadId == dozvoljeniRadId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(DozvoljeniRad dozvoljeniRad)
        {
            //Nije potrebna implementacija
        }
    }
}
