using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;
using ParcelaService.DTOs.ConfirmationDto;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za dozvoljeni rad.
    /// </summary>
    public class DozvoljeniRadProfile : Profile
    {
        public DozvoljeniRadProfile()
        {
            CreateMap<DozvoljeniRad, DozvoljeniRadDto>();
            CreateMap<DozvoljeniRadDto, DozvoljeniRad>();
            CreateMap<DozvoljeniRadCreateDto, DozvoljeniRad>();
            CreateMap<DozvoljeniRadUpdateDto, DozvoljeniRad>();
            CreateMap<DozvoljeniRad, DozvoljeniRad>();
        }
    }
}
