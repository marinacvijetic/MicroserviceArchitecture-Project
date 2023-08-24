using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Data
{
    public class LicitacijaRepository : ILicitacijaRepository
    {



        private readonly AppDbContext _context;

        public LicitacijaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void  CreateLicitacija(LicitacijaModel licitacija)
        {
            if (licitacija == null)
            {
                throw new ArgumentNullException(nameof(licitacija));
            }

            _context.Licitacije.Add(licitacija);
        }

        public void DeleteLicitacija(Guid licitacijaID)
        {
            var licitacijaITEM = GetLicitacijaByID(licitacijaID);
            if (licitacijaITEM != null)
            {
                _context.Remove(licitacijaITEM);
            }
        }

        public LicitacijaModel GetLicitacijaByID(Guid licitacijaID)
        {
            return _context.Licitacije.FirstOrDefault(p => p.licitacijaID == licitacijaID);
        }

        public List<LicitacijaModel> GetLicitacije()
        {
            return _context.Licitacije.ToList();
        }

        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() <= 0 );
        }

        public void UpdateLicitacija(LicitacijaModel licitacija)
        {
            //nije potrebna implementacija
        }


    }
}
