using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelaService.Auth;
using ParcelaService.Data;
using ParcelaService.DTOs;
using ParcelaService.DTOs.ConfirmationDto;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public ZasticenaZonaController(IZasticenaZonaRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca sve zaštićene zone
        /// </summary>
        /// <returns>Lista zaštićenih zona</returns>
        /// <response code = "200">Vraća listu zaštićenih zona</response>
        /// <response code = "204">Ne postoji nijedna zaštićena zona</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ZasticenaZonaDto>> GetAll()
        {
            Console.WriteLine("-->getting Zasticene zone");

            var zasticeneZoneItems = _repository.GetAll();


            return Ok(_mapper.Map<IEnumerable<ZasticenaZonaDto>>(zasticeneZoneItems));
        }

        /// <summary>
        /// Vraca zaštićenu zonu po ID-ju
        /// </summary>
        /// <param name="zasticenaZonaId">ID zaštićene zone</param>
        /// <returns>Odgovarajuća zaštićena zona</returns>
        /// <response code = "200">Vraća traženu zaštićenu zonu</response>
        /// <response code = "404">Nije pronađena tražena zaštićena zona</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{zasticenaZonaId}", Name = "GetById")]
        [AllowAnonymous]
        public ActionResult<ZasticenaZonaDto> GetById(Guid zasticenaZonaId)
        {
            var zasticenaZonaItem = _repository.GetById(zasticenaZonaId);
            if (zasticenaZonaItem != null)
            {
                return Ok(_mapper.Map<ZasticenaZonaDto>(zasticenaZonaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Vraća sve dozvoljene radove za id zasticene zone koji je prosledjen
        /// </summary>
        /// <param name="zasticenaZonaId">ID zasticene zone.</param>
        /// <returns>Lista dozvoljenih radova</returns>
        /// <response code = "200">Vraća listu dozvoljenih radova</response>
        /// <response code = "204">Ne postoji lista dozvoljenih radova</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("DozvoljeniRad/{zasticenaZonaId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DozvoljeniRad>> GetDozvoljeniRadovi(Guid zasticenaZonaId)
        {
            var dozvoljeniRadovi = _repository.GetDozvoljeniRadovi(zasticenaZonaId);
            if (dozvoljeniRadovi == null || dozvoljeniRadovi.Any())
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<DozvoljeniRadDto>>(dozvoljeniRadovi));
        }

        /// <summary>
        /// Kreiranje nove zaštićene zone
        /// </summary>
        /// <param name="zasticenaZonaCreateDto">Model zaštićene zone</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrdu o kreiranju zaštićene zone</returns>
        /// <response code = "201">Vraća kreiranu zaštićenu zonu</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje zaštićene zone nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja zaštićene zone</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<ZasticenaZonaDto> CreateZasticenaZona(ZasticenaZonaCreateDto zasticenaZonaCreateDto, [FromHeader(Name ="Authorization")] string key)
        {
            
            //key je Bearer AnaMarija
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var zasticenaZonaModel = _mapper.Map<ZasticenaZona>(zasticenaZonaCreateDto);
                _repository.Create(zasticenaZonaModel);
                _repository.SaveChanges();

                var zasticenaZonaDto = _mapper.Map<ZasticenaZonaDto>(zasticenaZonaModel);

                return CreatedAtRoute(nameof(GetById), new { ZasticenaZonaId = zasticenaZonaDto.ZasticenaZonaId }, zasticenaZonaDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating");
            }
        }

        /// <summary>
        /// Ažuriranje zaštićene zone
        /// </summary>
        /// <param name="zasticenaZona">Model zaštićene zone</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrdu o izmenama o zaštićenoj zoni</returns>
        /// <response code="200">Vraća ažuriranu zaštićenu zonu</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena zaštićena zona za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja zaštićene zone</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<ZasticenaZonaConfirmationDto> Update(ZasticenaZonaUpdateDto zasticenaZona, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldZasticenaZona = _repository.GetById(zasticenaZona.ZasticenaZonaId);
                if (oldZasticenaZona == null)
                {
                    return NotFound();
                }
                ZasticenaZona zasticenaZonaEntity = _mapper.Map<ZasticenaZona>(zasticenaZona);
                _mapper.Map(zasticenaZonaEntity, oldZasticenaZona);
                _repository.SaveChanges();
                return Ok(_mapper.Map<ZasticenaZonaDto>(oldZasticenaZona));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Brisanje zaštićene zone
        /// </summary>
        /// <param name="zasticenaZonaId">ID zaštićene zone</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Zaštićena zona uspešno obrisana</response>
        /// <response code="401">Lice koje želi da izvrši brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena zaštićena zona za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja zaštićene zone</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{zasticenaZonaId}")]
        public IActionResult Delete(Guid zasticenaZonaId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var zasticenaZona = _repository.GetById(zasticenaZonaId);
                if (zasticenaZona == null)
                {
                    return NotFound();
                }
                _repository.Delete(zasticenaZona.ZasticenaZonaId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa zaštićenim zonama
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetZasticenaZonaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
