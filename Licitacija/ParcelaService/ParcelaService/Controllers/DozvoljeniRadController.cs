using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelaService.Data;
using ParcelaService.DTOs;
using System.Collections.Generic;
using System;
using ParcelaService.DTOs.ConfirmationDto;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.Models;
using ParcelaService.Auth;
using Microsoft.AspNetCore.Http;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class DozvoljeniRadController :ControllerBase
    {
        private readonly IDozvoljeniRadRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public DozvoljeniRadController(IDozvoljeniRadRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository=repository;
            _mapper=mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve dozvoljene radove
        /// </summary>
        /// <returns>Lista dozvoljenih radova</returns>
        /// <response code = "200">Vraća listu dozvoljenih radova</response>
        /// <response code = "204">Ne postoji nijedan dozvoljeni rad</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DozvoljeniRadDto>> GetAll()
        {
            Console.WriteLine("-->getting Dozvoljeni radovi");

            var dozvoljeniRadItems = _repository.GetAll();


            return Ok(_mapper.Map<IEnumerable<DozvoljeniRadDto>>(dozvoljeniRadItems));
        }

        /// <summary>
        /// Vraca dozvoljene radove po ID-ju
        /// </summary>
        /// <param name="dozvoljeniRadId">ID dozvoljenog rada</param>
        /// <returns>Odgovarajući dozvoljeni rad</returns>
        /// <response code = "200">Vraća traženi dozvoljeni rad</response>
        /// <response code = "404">Nije pronađen traženi dozvoljeni rad</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{dozvoljeniRadId}", Name = "GetRadById")]
        [AllowAnonymous]
        public ActionResult<DozvoljeniRadDto> GetRadById(Guid dozvoljeniRadId)
        {
            var dozvoljeniRadItem = _repository.GetById(dozvoljeniRadId);
            if (dozvoljeniRadItem != null)
            {
                return Ok(_mapper.Map<DozvoljeniRadDto>(dozvoljeniRadItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreiranje novog dozvoljenog rada
        /// </summary>
        /// <param name="dozvoljeniRadCreateDto">Model dozvoljenog rada</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o kreiranju dozvoljenog rada</returns>
        /// <response code = "201">Vraća kreirani dozvoljeni rad</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje dozvoljenog rada nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja dozvoljenog rada</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<DozvoljeniRadDto> CreateDozvoljeniRad(DozvoljeniRadCreateDto dozvoljeniRadCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var dozvoljeniRadModel = _mapper.Map<DozvoljeniRad>(dozvoljeniRadCreateDto);
                _repository.Create(dozvoljeniRadModel);
                _repository.SaveChanges();

                var dozvoljeniRadDto = _mapper.Map<DozvoljeniRadDto>(dozvoljeniRadModel);

                return CreatedAtRoute(nameof(GetRadById), new { DozvoljeniRadId = dozvoljeniRadDto.DozvoljeniRadId }, dozvoljeniRadDto);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating");
            }
        }

        /// <summary>
        /// Ažuriranje dozvoljenih radova
        /// </summary>
        /// <param name="dozvoljeniRad">Model dozvoljenog rada</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o izmenama u dozvoljenom radu</returns>
        /// <response code="200">Vraća ažuriran dozvoljeni rada</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen dozvoljeni rad za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dozvoljenog rada</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<DozvoljeniRadConfirmationDto> Update(DozvoljeniRadUpdateDto dozvoljeniRad, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldDozvoljeniRad = _repository.GetById(dozvoljeniRad.DozvoljeniRadId);
                if (oldDozvoljeniRad == null)
                {
                    return NotFound();
                }
                DozvoljeniRad dozvoljeniRadEntity = _mapper.Map<DozvoljeniRad>(dozvoljeniRad);
                _mapper.Map(dozvoljeniRadEntity, oldDozvoljeniRad);
                _repository.SaveChanges();
                return Ok(_mapper.Map<DozvoljeniRadDto>(oldDozvoljeniRad));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Brisanje dozvoljenog rada
        /// </summary>
        /// <param name="dozvoljeniRadId">Id dozvoljenog rada</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Dozvoljeni rad uspešno obrisan</response>
        /// <response code="401">Lice koje želi da izvrši brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen dozvoljeni rad za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja dozvoljenog rada</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{dozvoljeniRadId}")]
        public IActionResult Delete(Guid dozvoljeniRadId, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var dozvoljeniRad = _repository.GetById(dozvoljeniRadId);
                if (dozvoljeniRad == null)
                {
                    return NotFound();
                }
                _repository.Delete(dozvoljeniRadId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }

        /// <summary>
        /// Vraća opcije za rad dozvoljenim radovima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetDozvoljeniRadOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
