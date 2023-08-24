using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;
using ZalbaService.Models.Zalba;

namespace ZalbaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za žalbu.
    /// </summary>
    public class ZalbaProfile : Profile
    {
        public ZalbaProfile()
        {
            // Source -> Target
            CreateMap<Zalba, ZalbaDTO>();
            CreateMap<ZalbaDTO, Zalba>();
            CreateMap<Zalba, Zalba>();
            CreateMap<ZalbaDTOCreation, Zalba>();
            CreateMap<ZalbaDTOUpdate, Zalba>();
        }
    }
}
