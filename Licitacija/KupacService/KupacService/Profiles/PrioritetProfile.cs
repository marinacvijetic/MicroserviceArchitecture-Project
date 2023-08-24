using AutoMapper;
using KupacService.Entities;
using KupacService.Models.BrojTable;
using KupacService.Models.Prioritet;

namespace KupacService.Profiles
{
    /// <summary>
    /// Profil prioriteta
    /// </summary>
    public class PrioritetProfile : Profile
    {
        /// <summary>
        /// Mapiranje entiteta.
        /// </summary>
        public PrioritetProfile() 
        {
            CreateMap<Prioritet, PrioritetDTO>();
            CreateMap<PrioritetDTO, Prioritet>();
            CreateMap<PrioritetDTOCreation, Prioritet>();
            CreateMap<Prioritet, PrioritetConfirmation>();
            CreateMap<PrioritetConfirmation, PrioritetDTOConfirmation>();
            CreateMap<PrioritetDTOUpdate, Prioritet>();
            CreateMap<Prioritet, Prioritet>();
        }
    }
}
