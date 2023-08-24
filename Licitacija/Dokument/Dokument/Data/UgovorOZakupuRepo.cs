using Dokument.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dokument.Data
{
    public class UgovorOZakupuRepo : IUgovorOZakupuRepo
    {
        private readonly AppDbContext _context;

        public UgovorOZakupuRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateUgovor(UgovorOZakupuEntity ugovor)
        {
            if (ugovor == null)
            {
                throw new ArgumentNullException(nameof(ugovor));
            }

            _context.Ugovori.Add(ugovor);
        }

        public void DeleteUgovor(Guid UgovorOZakupuID)
        {
            var ugovorITEM = GetUgovorById(UgovorOZakupuID);
            if (ugovorITEM != null)
            {
                _context.Remove(ugovorITEM);
            }
        }


        public IEnumerable<UgovorOZakupuEntity> GetAllUgovori()
        {
            return _context.Ugovori.ToList();
        }

        public UgovorOZakupuEntity GetUgovorById(Guid id)
        {
            return _context.Ugovori.FirstOrDefault(p => p.UgovorOZakupuID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUgovor(UgovorOZakupuEntity ugovor)
        {
            //nije potrebna implementacija
        }
    }
}
