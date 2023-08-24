using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za parcele.
    /// </summary>
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile() {
            CreateMap<Parcela, ParcelaDto>();
            CreateMap<ParcelaDto, Parcela>();
            CreateMap<ParcelaUpdateDto, Parcela>();
            CreateMap<ParcelaCreateDto, Parcela>();
            CreateMap<Parcela, Parcela>();
        }
    }
}
