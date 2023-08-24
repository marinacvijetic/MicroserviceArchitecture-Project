using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licitacija1.DTOs;
using Licitacija1.Entities;

namespace Licitacija1.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            CreateMap<DokumentModel, DokumentDTO>();
            CreateMap<DokumentDTO, DokumentModel>();
            CreateMap<DokumentCreateDTO, DokumentModel>();
            CreateMap<DokumentUpdateDTO, DokumentModel>();
            CreateMap<DokumentModel, DokumentModel>();
        }
    }
}
