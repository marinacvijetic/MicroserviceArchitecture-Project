using AutoMapper;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using KupacService.Helpers;
using KupacService.Models.OvlascenoLice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler koji omoćuava CRUD operacije za Ovlašćeno lice
    /// </summary>
    [Route("api/ovlascenaLica")]
    [ApiController]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IOvlascenoLiceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        /// <summary>
        /// Injektovanje potrebnih komponenti. 
        /// </summary>
        /// <param name="ovlascenoLiceRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = ovlascenoLiceRepository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sva ovlašćena lica.
        /// </summary>
        /// <returns>Lista ovlašćenih lica za kupca.</returns>
        /// <response code="200">Vraća listu ovlašćenih lica</response>
        /// <response code="404">Nije pronađeno ni jedno ovlašćeno lice.</response>
        [HttpGet]
        [HttpHead] //Podržavamo i HTTP head zahtev koji nam vraća samo zaglavlja u odgovoru    
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<OvlascenoLiceDTO>> GetOvlascenaLica()
        {
            var liceItems = _repository.GetAllOvlascenaLica();

            return Ok(_mapper.Map<IEnumerable<OvlascenoLiceDTO>>(liceItems));
        }

        /// <summary>
        /// Vraća jedno ovlašćeno lice na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID ovlašćenog lica</param>
        /// <returns>Vraća jedno konkretno ovlašćeno lice</returns>
        /// <response code="200">Vraća traženo ovlašćeno lice</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}", Name = "GetOvlascenoLiceByID")]
        public ActionResult<OvlascenoLiceDTO> GetOvlascenoLiceByID(Guid id)
        {
            var liceItem = _repository.GetOvlascenoLiceByID(id);
            if(liceItem != null)
            {
                return Ok(_mapper.Map<OvlascenoLiceDTO>(liceItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreira novo ovlašćeno lice.
        /// </summary>
        /// <param name="liceItem">Model ovlašćenog lica</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o kreiranomovlašćenom licu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog ovlašćenog lica \
        /// POST /api/ovlascenoLice \
        /// {     \
        ///     OvlascenoLiceID = "A1E4C8FD-7794-413F-A0DF-0CFD061BD377",
        ///     TipOvlascenogLica = TipOvlascenogLica.SrpskiDrzavljanin
        ///     Ime = "Ana",
        ///     Prezime = "Plavsic",
        ///     Adresa = "Beograd",
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirano ovlašćeno lice</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<OvlascenoLiceDTO> CreateOvlascenoLice(OvlascenoLiceDTO liceItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var liceModel = _mapper.Map<OvlascenoLice>(liceItem);
                _repository.CreateOvlascenoLice(liceModel);
                _repository.SaveChanges();

                var liceDto = _mapper.Map<OvlascenoLiceDTO>(liceModel);

                return CreatedAtRoute("GetOvlascenoLiceByID", new { ID = liceModel.OvlascenoLiceID }, liceDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Ažurira jedno ovlašćeno lice.
        /// </summary>
        /// <param name="liceItem">Model ovlašćenog lica</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o modifikovanom ovlašćenom licu.</returns>
        /// <response code="200">Vraća ažurirano u ovlašćeno lice</response>
        /// <response code="400">Ovlašćeno lice koje se ažurira nije pronadjeno</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja ovlašćenog lica</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<OvlascenoLiceDTO> UpdateOvlascenoLice(OvlascenoLiceDTO liceItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var liceModel = _mapper.Map<OvlascenoLice>(liceItem);

                if (liceModel != null)
                {
                    _repository.UpdateOvlascenoLice(liceModel);
                    _repository.SaveChanges();

                    var liceDto = _mapper.Map<OvlascenoLiceDTO>(liceModel);
                    return Ok(liceDto);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }

        }

        /// <summary>
        /// Vrši brisanje jednog ovlašćenog lica na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID ovlašćenog lica</param>
        /// <param name="key"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ovlašćeno lice nije uspešno obrisano</response>
        /// <response code="404">Nije pronađeno ovlašćeno lice</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja ovlašćenog lica</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteOvlascenoLice(Guid id, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                _repository.DeleteOvlascenoLice(id);
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
