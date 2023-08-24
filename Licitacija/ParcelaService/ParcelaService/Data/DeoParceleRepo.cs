using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class DeoParceleRepo : IDeoParceleRepo
    {
        private readonly ParcelaDbContext _context;
        public DeoParceleRepo(ParcelaDbContext context)
        {
            _context = context;
        }
        public void Create(DeoParcele deoParcele)
        {
            if (deoParcele == null) throw new ArgumentNullException(nameof(deoParcele));

            _context.DeloviParcele.Add(deoParcele);
        }

        public void Delete(Guid deoParceleId)
        {
            var deoParcele=GetById(deoParceleId);
            _context.Remove(deoParcele);
        }

        public IEnumerable<DeoParcele> GetAll(Guid? parcelaId)
        {
            return _context.DeloviParcele.Where(e => (parcelaId == null || e.ParcelaId == parcelaId)).ToList();
        }

        public DeoParcele GetById(Guid deoParceleId)
        {
            return _context.DeloviParcele.FirstOrDefault(p => p.DeoParceleId == deoParceleId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>= 0);
        }

        public void Update(DeoParcele deoParcele)
        {
            //implementacija nije potrebna
        }
    }
}
