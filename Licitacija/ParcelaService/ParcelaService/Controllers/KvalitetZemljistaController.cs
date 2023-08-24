using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelaService.Data;
using ParcelaService.DTOs;
using System.Collections.Generic;
using System;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.Models;
using ParcelaService.DTOs.ConfirmationDto;
using ParcelaService.DTOs.UpdateDto;
using Microsoft.AspNetCore.Http;
using ParcelaService.Auth;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class KvalitetZemljistaController : ControllerBase
    {
        private readonly IKvalitetZemljistaRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public KvalitetZemljistaController(IKvalitetZemljistaRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve kvalitete zemljišta
        /// </summary>
        /// <returns>Lista kvaliteta zemljišta</returns>
        /// <response code = "200">Vraća listu kvaliteta zemljišta</response>
        /// <response code = "204">Ne postoji nijedan kvalitet zemljišta</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<KvalitetZemljistaDto>> GetAll()
        {
            Console.WriteLine("-->getting Kvalitet zemljista");

            var kvalitetZemljistaItems = _repository.GetAll();


            return Ok(_mapper.Map<IEnumerable<KvalitetZemljistaDto>>(kvalitetZemljistaItems));
        }

        /// <summary>
        /// Vraća kvalitet zemljišta sa unetim ID
        /// </summary>
        /// <param name="kvalitetZemljistaId">ID kvaliteta zemljišta</param>
        /// <returns>Odgovarajući kvalitet zemljišta</returns>
        /// <response code = "200">Vraća traženi kvalitet zemljišta</response>
        /// <response code = "404">Nije pronađen traženi kvalitet zemljišta</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{kvalitetZemljistaId}", Name = "GetKvalitetById")]
        [AllowAnonymous]
        public ActionResult<KvalitetZemljistaDto> GetKvalitetById(Guid kvalitetZemljistaId)
        {
            var kvalitetZemljistaItem = _repository.GetById(kvalitetZemljistaId);
            if (kvalitetZemljistaItem != null)
            {
                return Ok(_mapper.Map<KvalitetZemljistaDto>(kvalitetZemljistaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreiranje novog kvaliteta zemljišta
        /// </summary>
        /// <param name="kvalitetZemljistaCreateDto">Model kvaliteta zemljišta</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrdu o kreiranju kvaliteta zemljišta</returns>
        /// <response code = "201">Vraća kreirani kvalitet zemljišta</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje kvaliteta zemljišta nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja kvaliteta zemljišta</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<KvalitetZemljistaDto> CreateKvalitetZemljista(KvalitetZemljistaCreateDto kvalitetZemljistaCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var kvalitetZemljistaModel = _mapper.Map<KvalitetZemljista>(kvalitetZemljistaCreateDto);
                _repository.Create(kvalitetZemljistaModel);
                _repository.SaveChanges();

                var kvalitetZemljistaDto = _mapper.Map<KvalitetZemljistaDto>(kvalitetZemljistaModel);

                return CreatedAtRoute(nameof(GetKvalitetById), new { KvalitetZemljistaId = kvalitetZemljistaDto.KvalitetZemljistaId }, kvalitetZemljistaDto);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ErrorCreating");
            }
        }

        /// <summary>
        /// Ažuriranje kvaliteta zemljišta
        /// </summary>
        /// <param name="kvalitetZemljista">Model kvaliteta zemljišta</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o izmenama u kvalitetu zemljšsta</returns>
        /// <response code="200">Vraća ažurirani kvalitet zemljišta</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen kvalitet zemljišta za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kvaliteta zemljišta</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<KvalitetZemljistaConfirmationDto> Update(KvalitetZemljistaUpdateDto kvalitetZemljista, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldKvalitetZemljista = _repository.GetById(kvalitetZemljista.KvalitetZemljistaId);
                if (oldKvalitetZemljista == null)
                {
                    return NotFound();
                }
                KvalitetZemljista kvalitetZemljistaEntity = _mapper.Map<KvalitetZemljista>(kvalitetZemljista);
                _mapper.Map(kvalitetZemljistaEntity, oldKvalitetZemljista);
                _repository.SaveChanges();
                return Ok(_mapper.Map<KvalitetZemljistaDto>(oldKvalitetZemljista));
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Brisanje kvaliteta zemljišta
        /// </summary>
        /// <param name="kvalitetZemljistaId">ID kvaliteta zemljišta</param>
        ///  <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kvalitet zemljišta uspešno obrisan</response>
        /// <response code="401">Lice koje želi da izvrši brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen kvalitet zemljišta  za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kvaliteta zemljišta</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{kvalitetZemljistaId}")]
        public IActionResult Delete(Guid kvalitetZemljistaId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var kvalitetZemljista = _repository.GetById(kvalitetZemljistaId);
                if (kvalitetZemljista == null)
                {
                    return NotFound();
                }
                _repository.Delete(kvalitetZemljistaId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }

        /// <summary>
        /// Vraća opcije za rad kvalitetima zemljišta
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKvalitetZemljistaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
