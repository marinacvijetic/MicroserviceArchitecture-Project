using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za zasticenu zonu.
    /// </summary>
    public class ZasticenaZonaProfile : Profile
    {
        public ZasticenaZonaProfile()
        {
            // Source -> Target
            CreateMap<ZasticenaZona, ZasticenaZonaDto>();
            CreateMap<ZasticenaZonaDto, ZasticenaZona>();
            CreateMap<ZasticenaZonaCreateDto, ZasticenaZona>();
            CreateMap<ZasticenaZonaUpdateDto, ZasticenaZona>();
            CreateMap<ZasticenaZona, ZasticenaZona>();
        }
    }
}
