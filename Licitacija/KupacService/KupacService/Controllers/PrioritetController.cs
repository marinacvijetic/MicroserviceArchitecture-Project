using AutoMapper;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using KupacService.Helpers;
using KupacService.Models.BrojTable;
using KupacService.Models.Kupac;
using KupacService.Models.Prioritet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler za entitet Prioritet koji omogućava sve CRUD operacije
    /// </summary>
    [Route("api/prioriteti")]
    [ApiController]
    public class PrioritetController : ControllerBase
    {
        private readonly IPrioritetRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        /// <summary>
        /// Injektovanje potrebnih komponenti
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public PrioritetController (IPrioritetRepository repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve prioritete.
        /// </summary>
        /// <returns>Lista prioriteta za kupca.</returns>
        /// <response code="200">Vraća listu prioriteta</response>
        /// <response code="404">Nije pronađen ni jedan prioritet.</response>
        [HttpGet]
        [HttpHead] //Podržavamo i HTTP head zahtev koji nam vraća samo zaglavlja u odgovoru    
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<PrioritetDTO>> GetPrioriteti() 
        {
            var prioritetItems = _repository.GetAllPrioriteti();

            return Ok(_mapper.Map<IEnumerable<PrioritetDTO>>(prioritetItems));
        }

        /// <summary>
        /// Vraća jedan prioritet na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID prioriteta</param>
        /// <returns>Vraća jedan prioritet</returns>
        /// <response code="200">Vraća traženi prioritet</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}", Name = "GetPrioritetByID")]
        public ActionResult<KupacDTO> GetPrioritetByID(int id)
        {
            var prioritetItem = _repository.GetPrioritetByID(id);
            if (prioritetItem != null)
            {
                return Ok(_mapper.Map<PrioritetDTO>(prioritetItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreira novi prioritet.
        /// </summary>
        /// <param name="prioritetItem">Model prioriteta</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o kreiranom prioritetu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog prioriteta \
        /// POST /api/prioriteti \
        /// {     \
        ///     PrioritetID = "A1E4C8FD-7794-413F-A0DF-0CFD061BD377",
        ///     PrioritetIzbor = "Kupac je vlasnik zemljišta pored onog koje se daje u zakup.",
        ///     
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirani prioritet</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<PrioritetDTO> CreatePrioritet(PrioritetDTO prioritetItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var prioritetModel = _mapper.Map<Prioritet>(prioritetItem);
                _repository.CreatePrioritet(prioritetModel);
                _repository.SaveChanges();

                var prioritetDto = _mapper.Map<PrioritetDTO>(prioritetModel);

                return CreatedAtRoute("GetPrioritetByID", new { ID = prioritetModel.PrioritetID }, prioritetDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Ažurira jedan prioritet.
        /// </summary>
        /// <param name="prioritetItem">Model prioriteta</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o modifikovanom prioritetu.</returns>
        /// <response code="200">Vraća ažuriran prioritet</response>
        /// <response code="400">Prioritet koji se ažurira nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja prioriteta</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<PrioritetDTO> UpdatePrioritet(PrioritetDTO prioritetItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var prioritetModel = _mapper.Map<Prioritet>(prioritetItem);

                if (prioritetModel != null)
                {
                    _repository.UpdatePrioritet(prioritetModel);
                    _repository.SaveChanges();

                    var prioritetDto = _mapper.Map<PrioritetDTO>(prioritetModel);
                    return Ok(prioritetDto);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }

        }

        /// <summary>
        /// Vrši brisanje jednog prioriteta na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID prioriteta</param>
        /// <param name="key"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Prioritet nije uspešno obrisan</response>
        /// <response code="404">Nije pronađen prioritet</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja  prioriteta</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeletePrioritet(int id, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                _repository.DeletePrioritet(id);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }
    }
}
