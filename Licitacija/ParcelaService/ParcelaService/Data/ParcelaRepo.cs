using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ParcelaRepo : IParcelaRepo
    {
        private readonly ParcelaDbContext _context;

        public ParcelaRepo(ParcelaDbContext context)
        {
            _context = context;
        }
        public void Create(Parcela parcela)
        {
            if(parcela== null) throw new ArgumentNullException(nameof(parcela));
            _context.Parcele.Add(parcela);
        }

        public void Delete(Guid parcelaId)
        {
            var parcela= GetById(parcelaId);
            _context.Remove(parcela);
        }

        public IEnumerable<Parcela> GetAll(Guid? katastarskaOpstinaId)
        {
            return _context.Parcele.Where(p => (katastarskaOpstinaId == null || p.KatastarskaOpstinaId == katastarskaOpstinaId)).ToList();
        }

        public Parcela GetById(Guid parcelaId)
        {
            return _context.Parcele.FirstOrDefault(p => p.ParcelaId == parcelaId);
        }

        public IEnumerable<DeoParcele> GetDeloveParcele(Guid parcelaId)
        {
            return _context.DeloviParcele.Where(p => p.ParcelaId == parcelaId).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Parcela parcela)
        {
           //nije potrebna implementacija
        }
    }
}
