using AutoMapper;
using KupacService.Entities;
using KupacService.Models.FizickoLice;
using KupacService.Models.Kupac;
using KupacService.Models.PravnoLice;

namespace KupacService.Profiles
{
    /// <summary>
    /// Profil kupca
    /// </summary>
    public class KupacProfile : Profile
    {
        /// <summary>
        /// Mapiranje entiteta kupac
        /// </summary>
        public KupacProfile() 
        {
            //Source(entity) -> Target(dto)
            CreateMap<Kupac, KupacDTO>();
            CreateMap<KupacDTOUpdate, Kupac>();
            CreateMap<KupacDTOCreation, Kupac>();
            CreateMap<KupacDTO, Kupac>();
            CreateMap<Kupac, Kupac>();

            CreateMap<FizickoLice, KupacDTO>();
            CreateMap<FizickoLice, FizickoLiceDTO>();
            CreateMap<FizickoLiceDTOCreation, FizickoLice>();
            CreateMap<FizickoLice, FizickoLiceConfirmation>();
            CreateMap<FizickoLiceConfirmation, FizickoLiceDTOConfirmation>();
            CreateMap<FizickoLiceDTOUpdate, FizickoLice>().IncludeBase<KupacDTOUpdate, Kupac>();

            CreateMap<PravnoLice, KupacDTO>();
            CreateMap<PravnoLice, PravnoLiceDTO>();
            CreateMap<PravnoLiceDTOCreation, PravnoLice>();
            CreateMap<PravnoLice, PravnoLiceConfirmation>();
            CreateMap<PravnoLiceConfirmation, PravnoLiceDTOConfirmation>();
            CreateMap<PravnoLiceDTOUpdate, PravnoLice>().IncludeBase<KupacDTOUpdate, Kupac>();
        }   
    }
}
