using Korisnici.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Korisnici.Data.IRepo
{
    public interface IKorisnikRepo
    {
        bool SaveChanges();

        IEnumerable<KorisnikEntity> GetAllKorisnici();
        KorisnikEntity GetKorisnikById(int id);

        void CreateKorisnik(KorisnikEntity korisnik);
        //dodala
        void DeleteKorisnik(int KorisnikID);

        void UpdateKorisnik(KorisnikEntity korisnik);
    }
}
