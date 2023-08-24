using AutoMapper;
using KupacService.Entities;
using KupacService.Models.BrojTable;
using KupacService.Models.Kupac;
using KupacService.Models.OvlascenoLice;
using KupacService.Models.SrpskiDrzavljanin;

namespace KupacService.Profiles
{
    /// <summary>
    /// Profil za broj table
    /// </summary>
    public class BrojTableProfile : Profile
    {
        /// <summary>
        /// Mapiranje entiteta broja table
        /// </summary>
        public BrojTableProfile() 
        {
            CreateMap<BrojTable, BrojTableDTO>();
            CreateMap<BrojTableDTO, BrojTable>();
            CreateMap<BrojTableDTOCreation, BrojTable>();
            CreateMap<BrojTable, BrojTableConfirmation>();
            CreateMap<BrojTableConfirmation, BrojTableDTOConfirmation>();
            CreateMap<BrojTableDTOUpdate, BrojTable>();
            CreateMap<BrojTable, BrojTable>();
        }
    }
}
