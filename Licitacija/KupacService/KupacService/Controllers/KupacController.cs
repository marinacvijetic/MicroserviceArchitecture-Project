using AutoMapper;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using KupacService.Helpers;
using KupacService.Models.KontaktOsoba;
using KupacService.Models.Kupac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler koji omogućava CRUD operacije za kupca.
    /// </summary>
    [Route("api/kupci")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        private readonly IKupacRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        /// <summary>
        /// Injektovanje potrebnih komponenti.
        /// </summary>
        /// <param name="kupacRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public KupacController(IKupacRepository kupacRepository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = kupacRepository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Lista kupaca.</returns>
        /// <response code="200">Vraća listu kontakt osoba</response>
        /// <response code="404">Nije pronađena ni jedna kontakt osoba.</response>
        [HttpGet]
        [HttpHead] //Podržavamo i HTTP head zahtev koji nam vraća samo zaglavlja u odgovoru    
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<KupacDTO>> GetKupci()
        {
            Console.WriteLine("--> Getting Kupci...");

            var kupacItems = _repository.GetAllKupci();

            return Ok(_mapper.Map<IEnumerable<KupacDTO>>(kupacItems));
        }

        /// <summary>
        /// Vraća jednog kupca na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <returns>Vraća jednog kupca</returns>
        /// <response code="200">Vraća traženog kupca</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}", Name="GetKupacByID")]
        public ActionResult<KupacDTO> GetKupacByID(Guid id) 
        {
            var kupacItem = _repository.GetKupacByID(id);
            if(kupacItem != null)
            {
                return Ok(_mapper.Map<KupacDTO>(kupacItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreira novu kontakt osobu.
        /// </summary>
        /// <param name="kupacItem">Model kontakt osobe</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o kreiranoj kontakt osobi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove kontakt osobe \
        /// POST /api/kontaktOsoba \
        /// {     \
        ///     KupacID = "A1E4C8FD-7794-413F-A0DF-0CFD061BD377",
        ///     TipKupca = TipKupca.FizickoLice,
        ///     OstvarenaPovrsina = 150
        ///     ...
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu kontakt osobu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<KupacDTO> CreateKupac(KupacDTO kupacItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                //Prosledjen je dto, ali repository radi sa entitetima
                //Zato se prvo vrsi mapiranje kako bi se kreirao privremeni entitet koji ce biti prosledjen u repository
                var kupacModel = _mapper.Map<Kupac>(kupacItem);
                _repository.CreateKupac(kupacModel);
                _repository.SaveChanges();

                //Mapiranje modela nazad u dto
                var kupacDto = _mapper.Map<KupacDTO>(kupacModel);

                return CreatedAtRoute("GetKupacByID", new { ID = kupacModel.KupacID }, kupacDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Ažurira jednog kupca.
        /// </summary>
        /// <param name="kupacItem">Model kupca</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o modifikovanom kupcu..</returns>
        /// <response code="200">Vraća ažuriranog kupca</response>
        /// <response code="400">Kupac koji se ažurira nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<KupacDTO> UpdateKupac(KupacDTO kupacItem, [FromHeader(Name ="Authorization")] string key) 
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var kupacModel = _mapper.Map<Kupac>(kupacItem);

                if (kupacModel != null)
                {
                    _repository.UpdateKupac(kupacModel);
                    _repository.SaveChanges();

                    var kupacDto = _mapper.Map<KupacDTO>(kupacModel);
                    return Ok(kupacDto);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }

        }

        /// <summary>
        /// Vrši brisanje jednog kupca na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <param name="key"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kupac nije uspešno obrisan</response>
        /// <response code="404">Nije pronađen kupac</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKupac(Guid id, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                _repository.DeleteKupac(id);
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
