using AutoMapper;
using Dokument.Entities;
using Dokument.Models.UgovorOZakupu;

namespace Dokument.Profiles
{
    public class UgovorProfile : Profile
    {
        public UgovorProfile() 
        {
            // source -> target
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuDTO>();
            CreateMap<UgovorOZakupuDTOCreate, UgovorOZakupuEntity>();

            CreateMap<UgovorOZakupuDTO, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuDTOUpdate, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuEntity>();

  
        }
    }
}
