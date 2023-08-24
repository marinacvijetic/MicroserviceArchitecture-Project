using AutoMapper;
using KatastarskaOpstinaService.DTOs;
using KatastarskaOpstinaService.DTOs.ConfirmationDto;
using KatastarskaOpstinaService.DTOs.CreationDto;
using KatastarskaOpstinaService.DTOs.UpdateDto;
using KatastarskaOpstinaService.Models;

namespace KatastarskaOpstinaService.Profiles
{
    public class KatastarskaOpstinaProfile : Profile
    {
        /// <summary>
        /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za Katastarske opstine.
        /// </summary>
        public KatastarskaOpstinaProfile()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, KatastarskaOpstina>();
            CreateMap<KatastarskaOpstinaCreationDto, KatastarskaOpstina>();
            CreateMap<KatastarskaOpstinaUpdateDto, KatastarskaOpstina>();
            CreateMap<KatastarskaOpstina, KatastarskaOpstina>();

            CreateMap<KatastarskaOpstinaConfirmation, KatastarskaOpstinaCreationDto>();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaConfirmationDto>();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaConfirmation>();
        }
    }
}
