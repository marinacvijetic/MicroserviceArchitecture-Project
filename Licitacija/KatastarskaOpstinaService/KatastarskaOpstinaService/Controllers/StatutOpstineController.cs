using AutoMapper;
using KatastarskaOpstinaService.Auth;
using KatastarskaOpstinaService.Data;
using KatastarskaOpstinaService.DTOs;
using KatastarskaOpstinaService.DTOs.CreationDto;
using KatastarskaOpstinaService.DTOs.UpdateDto;
using KatastarskaOpstinaService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace KatastarskaOpstinaService.Controllers
{
    [ApiController]
    [Route("api/statutOpstine")]
    [Produces("application/json", "application/xml")]
    public class StatutOpstineController : ControllerBase
    {
        private readonly IStatutOpstineRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public StatutOpstineController(IStatutOpstineRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository=repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca sve statute opstina
        /// </summary>
        /// <returns>Lista statuta opstina</returns>
        /// <response code= "200">Vraca listu statuta opstina</response>
        /// <response code= "204">Ne postoji nijedan statut opstine</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        [AllowAnonymous]
        public ActionResult <IEnumerable<StatutOpstineDto>> GetAll()
        {
            Console.WriteLine("--> getting Statut Opstine");

            var statutOpstineItems= _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<StatutOpstineDto>>(statutOpstineItems));  
        }

        /// <summary>
        /// Vraca statut opstine po ID-u
        /// </summary>
        /// <param name="statutOpstineId">ID statuta opstine</param>
        /// <returns>Odgovarajuci statut opstine</returns>
        /// <response code= "200">Vraca trazeni statut opstine</response>
        /// <response code= "204">Nije pronadjen trazeni statut opstine</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{statutOpstineId}", Name = "GetStatutById")]
        [AllowAnonymous]
        public ActionResult<StatutOpstineDto> GetStatutById(Guid statutOpstineId)
        {
            var statutOpstineItem = _repository.GetById(statutOpstineId);
            if (statutOpstineItem != null)
            {
                return Ok(_mapper.Map<StatutOpstineDto>(statutOpstineItem));
            }
            return NotFound();
        }

        /// <summary>
        /// Kreiranje novog statuta opstine
        /// </summary>
        /// <param name="statutOpstineCreateDto">Model statuta opstine</param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija(key vrednost: MajaCetic)</param>
        /// <returns></returns>
        /// <response code= "201">Vraca kreiran statut opstine</response>
        /// <response code= "401">Lice koje zeli da izvrsi kreiranje statuta opstine nije autorizovani korisnik</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom kreiranja stauta opstine</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<StatutOpstineDto> Create(StatutOpstineCreationDto statutOpstineCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var statutModel = _mapper.Map<StatutOpstine>(statutOpstineCreateDto);
                _repository.Create(statutModel);
                _repository.SaveChanges();

                var statutOpstineDto = _mapper.Map<StatutOpstineDto>(statutModel);

                return CreatedAtRoute(nameof(GetStatutById), new { StatutOpstineId = statutOpstineDto.StatutOpstineId }, statutOpstineDto);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "CreateError");
            }
        }

        /// <summary>
        /// Azuriranje statuta opstine
        /// </summary>
        /// <param name="statut">Model statuta opstine</param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda u azuriranju statuta opstine</returns>
        /// <response code= "200">Statut opstine azurirana</response>
        /// <response code= "401">Lice koje zeli da izvrsi brisanje statuta opstine nije autorizovani korisnik</response>
        /// <response code= "404">Nije pronadjen statut opstine za brisanje</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom brisanja statuta opstine</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<StatutOpstineCreationDto> Update(StatutOpstineUpdateDto statut, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldStatut = _repository.GetById(statut.StatutOpstineId);
                if (oldStatut == null)
                {
                    return NotFound();
                }
                StatutOpstine statutEntity = _mapper.Map<StatutOpstine>(statut);
                _mapper.Map(statutEntity, oldStatut);
                _repository.SaveChanges();
                return Ok(_mapper.Map<StatutOpstineDto>(oldStatut));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        /// <summary>
        /// Brisanje statuta opstine
        /// </summary>
        /// <param name="statutOpstineId">ID statuta opstine</param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns></returns>
        /// <response code= "204">Statut opstine uspesno obrisan</response>
        /// <response code= "401">Lice koje zeli da izvrsi brisanje statuta opstine nije autorizovani korisnik</response>
        /// <response code= "404">Nije pronadjena statut opstine za brisanje</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom brisanja statuta opstine</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{statutOpstineId}")]
        public IActionResult Delete(Guid statutOpstineId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var statut = _repository.GetById(statutOpstineId);
                if (statut == null)
                {
                    return NotFound();
                }
                _repository.Delete(statutOpstineId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa statutom opstine
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetStatutOpstinesOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
