using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za deo parcele.
    /// </summary>
    public class DeoParceleProfile : Profile
    {
        public DeoParceleProfile() 
        {
            CreateMap<DeoParcele, DeoParceleDto>();
            CreateMap<DeoParceleCreateDto, DeoParcele>();
            CreateMap<DeoParcele, DeoParceleUpdateDto>();
            CreateMap<DeoParceleUpdateDto, DeoParcele>();
            CreateMap<DeoParcele, DeoParcele>();
            CreateMap<DeoParceleDto, DeoParcele>();
        }
    }
}
