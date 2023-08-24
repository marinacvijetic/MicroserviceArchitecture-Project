using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Data
{
    public class LicitacijaDokumentRepository : ILicitacijaDokumentRepository
    {
        private readonly AppDbContext _context;

        public LicitacijaDokumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateLicitacijaDokument(DokumentModel licitacijaDokument)
        {
            if (licitacijaDokument == null)
            {
                throw new ArgumentNullException(nameof(licitacijaDokument));
            }

            _context.Dokumenti.Add(licitacijaDokument);
        }

        public void Delete(Guid dokumentID)
        {
            var dokumentITEM = GetDokumentByID(dokumentID);
            if (dokumentITEM != null)
            {
                _context.Remove(dokumentITEM);
            }
        }

        public List<DokumentModel> GetDokumenti()
        {
            return _context.Dokumenti.ToList();
        }

        public DokumentModel GetDokumentByID( Guid dokumentID)
        {
            return _context.Dokumenti.FirstOrDefault(p => p.dokumentID == dokumentID);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() <= 0);
        }

        public void UpdateLicitacijaDokument(DokumentModel licitacijaDokument)
        {
            //nije potrebna implementacija
        }

        public List<DokumentModel> GetDokumentByLicitacijaID(Guid LicitacijaID)
        {
            return _context.Dokumenti.Where(l => (l.licitacijaID == LicitacijaID)).ToList();
        }

    }
}
