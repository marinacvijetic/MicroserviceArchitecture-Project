using Korisnici.Data.IRepo;
using Korisnici.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Korisnici.Data.Repo
{
    public class KorisnikRepo : IKorisnikRepo
    {
        private readonly AppDbContext _context;

        public KorisnikRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateKorisnik(KorisnikEntity korisnik)
        {
            if (korisnik == null)
            {
                throw new ArgumentNullException(nameof(korisnik));
            }

            _context.Korisnici.Add(korisnik);
        }

        public void DeleteKorisnik(KorisnikEntity korisnik)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KorisnikEntity> GetAllKorisnici()
        {
            return _context.Korisnici.ToList();
        }

        public KorisnikEntity GetKorisnikById(int id)
        {
            return _context.Korisnici.FirstOrDefault(p => p.KorisnikID == id);
        }

        public void UpdateKorisnik(KorisnikEntity korisnik)
        {
            //nije potrebna implementacija
        }

        public void DeleteKorisnik(int KorisnikID)
        {
            var korisnikITEM = GetKorisnikById(KorisnikID);
            if (korisnikITEM != null)
            {
                _context.Remove(korisnikITEM);
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
