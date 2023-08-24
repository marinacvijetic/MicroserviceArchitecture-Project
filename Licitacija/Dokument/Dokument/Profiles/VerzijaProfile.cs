using AutoMapper;
using Dokument.Entities;
using Dokument.Models.VerzijaDokumenta;

namespace Dokument.Profiles
{
    public class VerzijaProfile : Profile
    {
        public VerzijaProfile()
        {
            // source -> target
            CreateMap<VerzijaDokumentaEntity, VerzijaDokumentaDTO>();
            CreateMap<VerzijaDokumentaDTOCreate, VerzijaDokumentaEntity>();

            CreateMap<VerzijaDokumentaDTO, VerzijaDokumentaEntity>();
            CreateMap<VerzijaDokumentaDTOUpdate, VerzijaDokumentaEntity>();
            CreateMap<VerzijaDokumentaEntity, VerzijaDokumentaEntity>();
        }
    }
}
