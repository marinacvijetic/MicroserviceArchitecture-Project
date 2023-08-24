using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelaService.Data;
using ParcelaService.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.Models;
using ParcelaService.DTOs.ConfirmationDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.Auth;
using Microsoft.AspNetCore.Http;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public ParcelaController(IParcelaRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository=repository;
            _mapper=mapper; 
            _authHelper=authHelper;
        }

        /// <summary>
        /// Vraća sve parcele ili opciono sve parcele koje pripadaju nekoj katastarskoj opštini
        /// </summary>
        /// <param name="katastarskaOpstinaId">ID katastarske opštine</param>
        /// <returns>Lista parcela</returns>
        /// <response code = "200">Vraća listu parcela</response>
        /// <response code = "204">Ne postoji nijedna parcela</response>
        [HttpGet]
        [HttpHead]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ParcelaDto>> GetAll(Guid? katastarskaOpstinaId)
        {
            Console.WriteLine("-->getting Percele");
            var parcele = _repository.GetAll(katastarskaOpstinaId);
            if (parcele == null || !parcele.Any())
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<ParcelaDto>>(parcele));
        }

        /// <summary>
        /// Vraća sve delove parcele čiji je ID prosleđen
        /// </summary>
        /// <param name="parcelaId">ID parcele</param>
        /// <returns>Lista delova parcele</returns>
        /// <response code = "200">Vraća listu delova parcela</response>
        /// <response code = "204">Ne postoji lista delova parcele</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("DeloviParcele/{parcelaId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DeoParceleDto>> GetDeloveParcele(Guid parcelaId)
        {
            var deloviParcele = _repository.GetDeloveParcele(parcelaId);
            if (deloviParcele == null || deloviParcele.Any())
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<DeoParceleDto>>(deloviParcele));
        }

        /// <summary>
        /// Vraća parcelu po ID-ju
        /// </summary>
        /// <param name="parcelaId">ID parcele</param>
        /// <returns>Odgovarajuća parcela</returns>
        /// <response code = "200">Vraća traženu parcelu</response>
        /// <response code = "404">Nije pronađena tražena parcela</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{parcelaId}", Name = "GetParcelaById")]
        [AllowAnonymous]
        public ActionResult<ParcelaDto> GetParcelaById(Guid parcelaId)
        {
            var parcelaItem = _repository.GetById(parcelaId);
            if (parcelaItem != null)
            {
                return Ok(_mapper.Map<ParcelaDto>(parcelaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreiranje nove parcele
        /// </summary>
        /// <param name="parcelaCreateDto">Model parcele</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o kreiranju parcele</returns>
        /// <response code = "201">Vraća kreiranu parcele</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje parcele nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja parcele</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<ParcelaDto> CreateParcela(ParcelaCreateDto parcelaCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var parcelaModel = _mapper.Map<Parcela>(parcelaCreateDto);
                _repository.Create(parcelaModel);
                _repository.SaveChanges();

                var parcelaDto = _mapper.Map<ParcelaDto>(parcelaModel);

                return CreatedAtRoute(nameof(GetParcelaById), new { ParcelaId = parcelaDto.ParcelaId }, parcelaDto);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating");
            }
        }

        /// <summary>
        /// Ažuriranje parcele
        /// </summary>
        /// <param name="parcela">Model parcele</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o izmenama u parceli</returns>
        /// <response code="200">Vraća ažuriranu parcelu</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena parcela za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja parcele</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<ParcelaConfirmationDto> Update(ParcelaUpdateDto parcela, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldParcela = _repository.GetById(parcela.ParcelaId);
                if (oldParcela == null)
                {
                    return NotFound();
                }
                Parcela parcelaEntity = _mapper.Map<Parcela>(parcela);
                _mapper.Map(parcelaEntity, oldParcela);
                _repository.SaveChanges();
                return Ok(_mapper.Map<ParcelaDto>(oldParcela));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Brisanje parcele
        /// </summary>
        /// <param name="parcelaId">Id parcele</param>
        ///  <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcela uspešno obrisana</response>
        /// <response code="401">Lice koje želi da izvrši brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena parcela za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja parcele</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{parcelaId}")]
        public IActionResult Delete(Guid parcelaId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var parcela = _repository.GetById(parcelaId);
                if (parcela == null)
                {
                    return NotFound();
                }
                _repository.Delete(parcelaId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa parcelama
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetParcelaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
