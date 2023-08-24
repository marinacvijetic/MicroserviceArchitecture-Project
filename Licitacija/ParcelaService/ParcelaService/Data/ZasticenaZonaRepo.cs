using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ZasticenaZonaRepo : IZasticenaZonaRepo
    {
        private readonly ParcelaDbContext _context;
        public ZasticenaZonaRepo(ParcelaDbContext context)
        {
            _context = context;
        }
        public void Create(ZasticenaZona zasticenaZona)
        {
            if (zasticenaZona== null) throw new ArgumentNullException(nameof(zasticenaZona));
            _context.ZasticeneZone.Add(zasticenaZona);
        }

        public void Delete(Guid zasticenaZonaId)
        {
            var zasticenaZona = GetById(zasticenaZonaId);
            _context.Remove(zasticenaZona);
        }

        public IEnumerable<DozvoljeniRad> GetDozvoljeniRadovi(Guid zasticenaZonaId)
        {
            return _context.DozvoljeniRadovi.Where(p => p.ZasticenaZonaId == zasticenaZonaId).ToList();
        }
        public IEnumerable<ZasticenaZona> GetAll()
        {
            return _context.ZasticeneZone.ToList();
        }

        public ZasticenaZona GetById(Guid zasticenaZonaId)
        {
            return _context.ZasticeneZone.FirstOrDefault(p => p.ZasticenaZonaId == zasticenaZonaId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(ZasticenaZona zasticenaZona)
        {
            //nije potrebna implementacija
        }
    }
}
