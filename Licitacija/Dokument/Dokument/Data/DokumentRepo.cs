using Dokument.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dokument.Data
{
    public class DokumentRepo : IDokumentRepo
    {
        private readonly AppDbContext _context;

        public DokumentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateDokument(DokumentEntity dokument)
        {
            if (dokument == null)
            {
                throw new ArgumentNullException(nameof(dokument));
            }

            _context.Dokumenti.Add(dokument);
        }

        public IEnumerable<DokumentEntity> GetAllDokumenti()
        {
            return _context.Dokumenti.ToList();
        }

        public DokumentEntity GetDokumentById(int id)
        {
            return _context.Dokumenti.FirstOrDefault(p => p.DokumentID == id);
        }

        public void UpdateDokument(DokumentEntity dokument)
        {
            //nije potrebna implementacija
        }

        public void DeleteDokument(int DokumentID)
        {
            var dokumentITEM = GetDokumentById(DokumentID);
            if (dokumentITEM != null)
            {
                _context.Remove(dokumentITEM);
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() <= 0);
        }
    }
}
