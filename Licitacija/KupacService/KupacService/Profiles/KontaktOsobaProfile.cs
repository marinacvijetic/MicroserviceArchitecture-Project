using AutoMapper;
using KupacService.Entities;
using KupacService.Models.BrojTable;
using KupacService.Models.KontaktOsoba;

namespace KupacService.Profiles
{
    /// <summary>
    /// Profil Kontakt osobe
    /// </summary>
    public class KontaktOsobaProfile : Profile
    {
        /// <summary>
        /// Mapiranje entiteta kontakt osobe
        /// </summary>
        public KontaktOsobaProfile() 
        {
            CreateMap<KontaktOsoba, KontaktOsobaDTO>();
            CreateMap<KontaktOsobaDTO, KontaktOsoba>();
            CreateMap<KontaktOsobaDTOCreation, KontaktOsoba>();
            CreateMap<KontaktOsoba, KontaktOsobaConfirmation>();
            CreateMap<KontaktOsobaConfirmation, KontaktOsobaDTOConfirmation>();
            CreateMap<KontaktOsobaDTOUpdate, KontaktOsoba>();
            CreateMap<KontaktOsoba, KontaktOsoba>();
        }
    }
}
