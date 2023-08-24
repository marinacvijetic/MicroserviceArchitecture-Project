using AutoMapper;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using KupacService.Helpers;
using KupacService.Models.BrojTable;
using KupacService.Models.KontaktOsoba;
using KupacService.Models.Kupac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler za Kontakt osobu koji omogućava CRUD operacije. 
    /// </summary>
    [Route("api/kontaktOsobe")]
    [ApiController]
    public class KontaktOsobaController : ControllerBase
    {
        private readonly IKontaktOsobaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        /// <summary>
        /// Instanciranje neophodnih komponenti. 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public KontaktOsobaController(IKontaktOsobaRepository repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve kontakt osobe.
        /// </summary>
        /// <returns>Lista kontakt osoba za pravno lice.</returns>
        /// <response code="200">Vraća listu kontakt osoba</response>
        /// <response code="404">Nije pronađena ni jedna kontakt osoba.</response>
        [HttpGet]
        [HttpHead] //Podržavamo i HTTP head zahtev koji nam vraća samo zaglavlja u odgovoru    
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<KontaktOsobaDTO>> GetKontaktOsobe() 
        {
            var osobaItems = _repository.GetAllKontaktOsobe();

            return Ok(_mapper.Map<IEnumerable<KontaktOsobaDTO>>(osobaItems));
        }

        /// <summary>
        /// Vraća jednu kontakt osobu na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID Kontakt osobe</param>
        /// <returns>Vraća jednu konkretnu osobu</returns>
        /// <response code="200">Vraća traženu kontakt osobu</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}", Name = "GetKontaktOsobuByID")]
        public ActionResult<KontaktOsobaDTO> GetKontaktOsobuByID(Guid id)
        {
            var osobaItem = _repository.GetKontaktOsobuByID(id);
            if (osobaItem != null)
            {
                return Ok(_mapper.Map<KontaktOsobaDTO>(osobaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreira novu kontakt osobu.
        /// </summary>
        /// <param name="osobaItem">Model kontakt osobe</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o kreiranoj kontakt osobi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove kontakt osobe \
        /// POST /api/kontaktOsoba \
        /// {     \
        ///     KontaktOsobaID = "A1E4C8FD-7794-413F-A0DF-0CFD061BD377",
        ///     Ime = "Ana",
        ///     Prezime = "Plavsic",
        ///     Funkcija = "Menadzer",
        ///     Telefon = "065824545"
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu kontakt osobu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<KontaktOsobaDTO> CreateKontaktOsobu(KontaktOsobaDTO osobaItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var osobaModel = _mapper.Map<KontaktOsoba>(osobaItem);
                _repository.CreateKontaktOsobu(osobaModel);
                _repository.SaveChanges();

                var osobaDto = _mapper.Map<KontaktOsobaDTO>(osobaModel);

                return CreatedAtRoute("GetKontaktOsobuByID", new { ID = osobaModel.KontaktOsobaID }, osobaDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Ažurira jednu kontakt osobu.
        /// </summary>
        /// <param name="osobaItem">Model kontakt osobe</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o modifikovanoj kontakt osobi.</returns>
        /// <response code="200">Vraća ažuriran u kontakt osobu</response>
        /// <response code="400">Kontakt osoba koja se ažurira nije pronadjena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kontakt osobe</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<KontaktOsobaDTO> UpdateKontaktOsobu(KontaktOsobaDTO osobaItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var osobaModel = _mapper.Map<KontaktOsoba>(osobaItem);

                if (osobaModel != null)
                {
                    _repository.UpdateKontaktOsobu(osobaModel);
                    _repository.SaveChanges();

                    var osobaDto = _mapper.Map<KontaktOsobaDTO>(osobaModel);
                    return Ok(osobaDto);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }


        }

        /// <summary>
        /// Vrši brisanje jedne kontakt osobe na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID kontakt osobe</param>
        /// <param name="key"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kontakt osoba nije uspešno obrisana</response>
        /// <response code="404">Nije pronađena kontakt osoba</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kontakt osobe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKontaktOsobu(Guid id, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                _repository.DeleteKontaktOsobu(id);
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
