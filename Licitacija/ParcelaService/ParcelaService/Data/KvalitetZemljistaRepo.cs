using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KvalitetZemljistaRepo : IKvalitetZemljistaRepo
    {
        private readonly ParcelaDbContext _context;
        public KvalitetZemljistaRepo(ParcelaDbContext context)
        {
            _context = context;
        }
        public void Create(KvalitetZemljista kvalitetZemljista)
        {
            if (kvalitetZemljista == null) throw new ArgumentNullException(nameof(kvalitetZemljista));

            _context.KvalitetiZemljista.Add(kvalitetZemljista);
        }

        public void Delete(Guid kvalitetZemljistaId)
        {
            var kvalitet = GetById(kvalitetZemljistaId);
            _context.Remove(kvalitet);
        }

        public IEnumerable<KvalitetZemljista> GetAll()
        {
            return _context.KvalitetiZemljista.ToList();
        }

        public KvalitetZemljista GetById(Guid kvalitetZemljistaId)
        {
            return _context.KvalitetiZemljista.FirstOrDefault(p => p.KvalitetZemljistaId == kvalitetZemljistaId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(KvalitetZemljista kvalitetZemljista)
        {
            //nije potrebna implementacija
        }
    }
}
