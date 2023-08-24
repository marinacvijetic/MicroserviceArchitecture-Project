using AutoMapper;
using Dokument.Entities;
using Dokument.Models.Dokument;

namespace Dokument.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            // source -> target
            CreateMap<DokumentEntity, DokumentDTO>();
            CreateMap<DokumentDTOCreate, DokumentEntity>();

            CreateMap<DokumentDTO, DokumentEntity>();
            CreateMap<DokumentDTOUpdate, DokumentEntity>();
            CreateMap<DokumentEntity, DokumentEntity>();
        }
    }
}
