using Dokument.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dokument.Data
{
    public class VerzijaDokumentaRepo : IVerzijaDokumentaRepo
    {
        private readonly AppDbContext _context;

        public VerzijaDokumentaRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateVerzija(VerzijaDokumentaEntity verzija)
        {
            if (verzija == null)
            {
                throw new ArgumentNullException(nameof(verzija));
            }

            _context.VerzijeDokumenata.Add(verzija);
        }

        public void DeleteVerzija(Guid VerzijaID)
        {
            var verzijaITEM = GetVerzijaById(VerzijaID);
            if (verzijaITEM != null)
            {
                _context.Remove(verzijaITEM);
            }
        }

        public IEnumerable<VerzijaDokumentaEntity> GetAllVerzije()
        {
            return _context.VerzijeDokumenata.ToList();
        }

        public VerzijaDokumentaEntity GetVerzijaById(Guid id)
        {
            return _context.VerzijeDokumenata.FirstOrDefault(p => p.VerzijaID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateVerzija(VerzijaDokumentaEntity ugovor)
        {
            //nije potrebna implementacija
        }
    }
}
