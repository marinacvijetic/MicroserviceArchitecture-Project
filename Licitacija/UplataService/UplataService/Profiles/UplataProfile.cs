using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za uplatu.
    /// </summary>
    public class UplataProfile : Profile
    {
        public UplataProfile()
        {
            // Source -> Target
            CreateMap<Uplata, UplataDTO>();
            CreateMap<UplataDTO, Uplata>();
            CreateMap<Uplata, Uplata>();
            CreateMap<UplataDTOCreation, Uplata>();
            CreateMap<UplataDTOUpdate, Uplata>();
        }
    }
}
