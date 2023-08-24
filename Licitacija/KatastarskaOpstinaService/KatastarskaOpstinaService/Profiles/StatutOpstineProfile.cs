using AutoMapper;
using KatastarskaOpstinaService.DTOs;
using KatastarskaOpstinaService.DTOs.ConfirmationDto;
using KatastarskaOpstinaService.DTOs.CreationDto;
using KatastarskaOpstinaService.DTOs.UpdateDto;
using KatastarskaOpstinaService.Models;

namespace KatastarskaOpstinaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za statut opstine.
    /// </summary>
    public class StatutOpstineProfile :Profile
    {
        public StatutOpstineProfile()
        {
            CreateMap<StatutOpstine, StatutOpstineDto>();
            CreateMap<StatutOpstineDto, StatutOpstine>();
            CreateMap<StatutOpstineCreationDto, StatutOpstine>();
            CreateMap<StatutOpstineUpdateDto, StatutOpstine>();
            CreateMap<StatutOpstine, StatutOpstine>();

            CreateMap<StatutOpstineConfirmation, StatutOpstineCreationDto>();
            CreateMap<StatutOpstine, StatutOpstineConfirmationDto>();
            CreateMap<StatutOpstine, StatutOpstineConfirmation>();

        }
        

    }
}
