using AutoMapper;
using Korisnici.Entities;
using Korisnici.Models.Korisnik;

namespace Korisnici.Profiles
{
    public class KorisniciProfile : Profile
    {
        public KorisniciProfile()
        {
            // source -> target
            CreateMap<KorisnikEntity, KorisnikDTO>();
            CreateMap<KorisnikDTOCreate, KorisnikEntity>();
            CreateMap<KorisnikDTOUpdate, KorisnikEntity>();
        }
    }
}
