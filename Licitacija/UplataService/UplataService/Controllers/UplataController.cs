using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Auth;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Controllers
{
    [Route("api/uplate")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRep _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public UplataController(IUplataRep repository, IMapper mapper, IAuthHelper authhelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authhelper;
        }

        /// <summary>
        /// Vraća sve uplate
        /// </summary>
        /// <response code = "200">Vraća listu uplata</response>
        /// <response code = "204">Ne postoji nijedna uplata</response>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UplataDTO>> GetUplate(Guid? kupacId)
        {
            Console.WriteLine("Getting uplate....");
            var uplataItem = _repository.GetAllUplate(kupacId);
            return Ok(_mapper.Map<IEnumerable<UplataDTO>>(uplataItem));
        }

        /// <summary>
        /// Vraća ulatu sa prosleđeenim id-jem
        /// </summary>
        /// <param name="uplataId">Id uplate</param>
        /// <returns>Lista delova uplate</returns>
        /// <response code = "200">Vraća uplatu</response>
        /// <response code = "204">Ne postoji nijedna uplata sa tim id-jem</response>
        [AllowAnonymous]
        [HttpGet("{ID}", Name = "GetUplataById")]
        public ActionResult<UplataDTO> GetUplataById(Guid ID)
        {
            Console.WriteLine("Getting uplata...");

            var uplataItem = _repository.GetUplataById(ID);

            if (uplataItem != null)
            {
                return Ok(_mapper.Map<UplataDTO>(uplataItem));
            }
            return NotFound();
        }

        /// <summary>
        /// Kreiranje nove uplate
        /// </summary>
        /// <param name="uplataCreateDto">Model uplate</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Potvrda o kreiranju uplate</returns>
        /// <response code = "201">Vraća kreiranu uplatu</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje uplate nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja uplate</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<UplataDTO> CreateUplata(UplataDTOCreation uplataCreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var uplata = _mapper.Map<Uplata>(uplataCreateDto);
                _repository.CreateUplata(uplata);
                _repository.SaveChanges();

                var uplataDTO = _mapper.Map<UplataDTO>(uplata);

                return CreatedAtRoute(nameof(GetUplataById), new { ID = uplataDTO.UplataID }, uplataDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Ažuriranje zalbe
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Potvrda o izmenama u uplati</returns>
        /// <response code="200">Vraća ažuriranu uplatu</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje uplate nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena uplata za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja uplate</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<UplataDTO> UpdateUplata(UplataDTOUpdate uplt, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldUplata = _repository.GetUplataById(uplt.UplataId);
                if (oldUplata == null)
                {
                    return NotFound();
                }
                Uplata uplataEntity = _mapper.Map<Uplata>(uplt);
                _mapper.Map(uplataEntity, oldUplata);
                _repository.SaveChanges();
                return Ok(_mapper.Map<UplataDTO>(oldUplata));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Brisanje uplate
        /// </summary>
        /// <param name="uplataId">Id uplate</param>
        ///  <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Uplata uspešno obrisana</response>
        /// <response code="401">Lice koje želi da izvrši brisanje uplate nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena uplata za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja uplate</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{uplataId}")]
        public IActionResult DeleteUplata(Guid uplataId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var uplt = _repository.GetUplataById(uplataId);
                if (uplt == null)
                {
                    return NotFound();
                }
                _repository.DeleteUplata(uplt.UplataID);
                _repository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }
    }
}
