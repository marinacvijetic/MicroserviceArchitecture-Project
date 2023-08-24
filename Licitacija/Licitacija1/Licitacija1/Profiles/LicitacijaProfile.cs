using AutoMapper;
using Licitacija1.DTOs;
using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Profiles
{
    public class LicitacijaProfile : Profile
    {
        public LicitacijaProfile ()
        {
            // source -> target
            CreateMap<LicitacijaModel, LicitacijaDTO>();
            CreateMap<LicitacijaDTO, LicitacijaModel>();
            CreateMap<LicitacijaCreateDTO, LicitacijaModel>();
            CreateMap<LicitacijaUpdateDTO, LicitacijaModel>();
            CreateMap<LicitacijaModel, LicitacijaModel>();

        }
    }
}
