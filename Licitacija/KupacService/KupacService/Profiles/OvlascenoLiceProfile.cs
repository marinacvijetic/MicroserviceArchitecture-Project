using AutoMapper;
using KupacService.Entities;
using KupacService.Models.FizickoLice;
using KupacService.Models.Kupac;
using KupacService.Models.OvlascenoLice;
using KupacService.Models.SrpskiDrzavljanin;
using KupacService.Models.StraniDrzavljanin;

namespace KupacService.Profiles
{
    /// <summary>
    /// Ovlašćeno lice 
    /// </summary>
    public class OvlascenoLiceProfile : Profile
    {
        /// <summary>
        /// Mapiranje entiteta
        /// </summary>
        public OvlascenoLiceProfile() 
        {
            CreateMap<OvlascenoLice, OvlascenoLiceDTO>();
            CreateMap<OvlascenoLiceDTOUpdate, OvlascenoLice>();
            CreateMap<OvlascenoLiceDTOCreation, OvlascenoLice>();
            CreateMap<OvlascenoLiceDTO, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLice>();

            CreateMap<SrpskiDrzavljanin, OvlascenoLiceDTO>();
            CreateMap<SrpskiDrzavljanin, SrpskiDrzavljaninDTO>();
            CreateMap<SrpskiDrzavljaninDTOCreation, SrpskiDrzavljanin>();
            CreateMap<SrpskiDrzavljanin, SrpskiDrzavljaninConfirmation>();
            CreateMap<SrpskiDrzavljaninConfirmation, SrpskiDrzavljaninDTOConfirmation>();
            CreateMap<SrpskiDrzavljaninDTOUpdate, SrpskiDrzavljanin>().IncludeBase<OvlascenoLiceDTOUpdate, OvlascenoLice>();

            CreateMap<StraniDrzavljanin, OvlascenoLiceDTO>();
            CreateMap<StraniDrzavljanin, StraniDrzavljaninDTO>();
            CreateMap<StraniDrzavljaninDTOCreation, StraniDrzavljanin>();
            CreateMap<StraniDrzavljanin, StraniDrzavljaninConfirmation>();
            CreateMap<StraniDrzavljaninConfirmation, StraniDrzavljaninDTOConfirmation>();
            CreateMap<StraniDrzavljaninDTOUpdate, StraniDrzavljanin>().IncludeBase<OvlascenoLiceDTOUpdate, OvlascenoLice>();
        }
    }
}
