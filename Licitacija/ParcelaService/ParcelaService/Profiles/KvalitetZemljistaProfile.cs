using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za kvalitet zemljista.
    /// </summary>
    public class KvalitetZemljistaProfile : Profile
    {
        public KvalitetZemljistaProfile()
        {
            CreateMap<KvalitetZemljista, KvalitetZemljistaDto>();
            CreateMap<KvalitetZemljistaDto, KvalitetZemljista>();
            CreateMap<KvalitetZemljistaCreateDto, KvalitetZemljista>();
            CreateMap<KvalitetZemljistaUpdateDto, KvalitetZemljista>();
            CreateMap<KvalitetZemljista, KvalitetZemljista>();
        }
    }
}
