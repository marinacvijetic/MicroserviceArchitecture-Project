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
using ParcelaService.Auth;
using Microsoft.AspNetCore.Http;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class DeoParceleController :ControllerBase
    {
        private readonly IDeoParceleRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public DeoParceleController(IDeoParceleRepo repository, IMapper mapper, IAuthHelper authHelper) {
            _repository=repository;
            _mapper=mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve delove parcele ili opciono sve delove parcele sa unetim Id-jem
        /// </summary>
        /// <param name="parcelaId">Id parcele</param>
        /// <returns>Lista delova parcele</returns>
        /// <response code = "200">Vraća listu delova parcela</response>
        /// <response code = "204">Ne postoji nijedan deo parcele</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DeoParceleDto>> GetAll(Guid ?parcelaId)
        {
            Console.WriteLine("-->getting deo parcele");

            var deoParceleItems = _repository.GetAll(parcelaId);


            return Ok(_mapper.Map<IEnumerable<DeoParceleDto>>(deoParceleItems));
        }

        /// <summary>
        /// Vraća deo parcele sa unetim Id-jem
        /// </summary>
        /// <param name="deoParceleId">Id dela parcele</param>
        /// <returns>Odgovarajući deo parcele</returns>
        /// <response code = "200">Vraća traženi deo parcele</response>
        /// <response code = "404">Nije pronađena traženi deo parcele</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{deoParceleId}", Name = "GetDeoById")]
        [AllowAnonymous]
        public ActionResult<DeoParceleDto> GetDeoById(Guid deoParceleId)
        {
            DeoParcele deoParceleItem = _repository.GetById(deoParceleId);
           
            if (deoParceleItem != null)
            {
                Console.WriteLine(deoParceleItem.KvalitetZemljistaId);
                return Ok(_mapper.Map<DeoParceleDto>(deoParceleItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreiranje novog dela parcele
        /// </summary>
        /// <param name="deoParceleCreateDto">Model dela parcele</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o kreiranju dela parcele</returns>
        ///  <response code = "201">Vraća kreirani deo parcele</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje dela parcele nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja dela parcele</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<DeoParceleDto> CreateDeoParcele(DeoParceleCreateDto deoParceleCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var deoParceleModel = _mapper.Map<DeoParcele>(deoParceleCreateDto);
                _repository.Create(deoParceleModel);
                _repository.SaveChanges();

                var deoParceleDto = _mapper.Map<DeoParcele>(deoParceleModel);

                return CreatedAtRoute(nameof(GetDeoById), new { DeoParceleId = deoParceleDto.DeoParceleId }, deoParceleDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }
        /// <summary>
        /// Ažuriranje dela parcele
        /// </summary>
        /// <param name="deoParcele">Model dela parcele</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Potvrda o izmenama u delu parcele</returns>
        /// <response code="200">Vraća ažurirani deo parcele</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen deo parcele za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dela parcele</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<DeoParceleConfirmationDto> Update(DeoParceleUpdateDto deoParcele, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldDeo = _repository.GetById(deoParcele.DeoParceleId);
                if (oldDeo == null)
                {
                    return NotFound();
                }
                DeoParcele deoEntity = _mapper.Map<DeoParcele>(deoParcele);
                _mapper.Map(deoEntity, oldDeo);
                _repository.SaveChanges();
                return Ok(_mapper.Map<DeoParceleDto>(oldDeo));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "UpdateError");
            }
        }

        /// <summary>
        /// Brisanje dela parcele
        /// </summary>
        /// <param name="deoParceleId">ID dela parcele</param>
        ///  <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer AnaMarija)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Deo parcele uspešno obrisan</response>
        /// <response code="401">Lice koje želi da izvrši brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen deo parcele za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja dela parcele</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{deoParceleId}")]
        public IActionResult Delete(Guid deoParceleId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var deo = _repository.GetById(deoParceleId);
                if (deo == null)
                {
                    return NotFound();
                }
                _repository.Delete(deoParceleId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Vraća opcije za rad delovima parcele
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetDeoParceleOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }


    }
}
