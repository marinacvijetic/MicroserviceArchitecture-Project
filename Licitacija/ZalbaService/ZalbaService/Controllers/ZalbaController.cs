using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Auth;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models.Zalba;


namespace ZalbaService.Controllers
{
    [Route("api/zalbe")]
    [ApiController]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRep _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        public ZalbaController(IZalbaRep repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve žalbe
        /// </summary>
        /// <response code = "200">Vraća listu žalbi</response>
        /// <response code = "204">Ne postoji nijedna žalba</response>

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<ZalbaDTO>> GetZalbe()
        {
            Console.WriteLine("Getting zalbe....");
            var zalbaItem = _repository.GetAllZalbe();
            return Ok(_mapper.Map<IEnumerable<ZalbaDTO>>(zalbaItem));
        }

        /// <summary>
        /// Vraća zalbu sa prosleđeenim id-jem
        /// </summary>
        /// <param name="zalbaId">Id žalbe</param>
        /// <returns>Lista delova žalbe</returns>
        /// <response code = "200">Vraća žalbu</response>
        /// <response code = "204">Ne postoji nijedna žalba sa tim id-jem</response>

        [AllowAnonymous]
        [HttpGet("{ID}", Name = "GetZalbaById")]
        public ActionResult<ZalbaDTO> GetZalbaById(Guid ID)
        {
            Console.WriteLine("Getting zalba...");

            var zalbaItem = _repository.GetZalbaById(ID);

            if (zalbaItem != null)
            {
                return Ok(_mapper.Map<ZalbaDTO>(zalbaItem));
            }
            return NotFound();
        }

        /// <summary>
        /// Kreiranje nove žalbe
        /// </summary>
        /// <param name="zalbacreateDto">Model žalbe</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Potvrda o kreiranju žalbe</returns>
        /// <response code = "201">Vraća kreiranu žalbu</response>
        /// <response code="401">Lice koje želi da izvrši kreiranje žalbe nije autorizovani korisnik</response>
        /// <response code = "500">Došlo je do greške na serveru prilikom kreiranja žalbe</response>

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<ZalbaDTO> CreateZalba(ZalbaDTOCreation zalbacreateDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var zalba = _mapper.Map<Zalba>(zalbacreateDto);
                _repository.CreateZalba(zalba);
                _repository.SaveChanges();

                var zalbaDto = _mapper.Map<ZalbaDTO>(zalba);

                return CreatedAtRoute(nameof(GetZalbaById), new { ID = zalbaDto.ZalbaID }, zalbaDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Ažuriranje zalbe
        /// </summary>
        /// <param name="zalba">Model žalbe</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Potvrda o izmenama u žalbi</returns>
        /// <response code="200">Vraća ažuriranu žalbu</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje žalbe nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena žalba za ažuriranje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja žalbe</response>

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<ZalbaDTO> UpdateZalba(ZalbaDTOUpdate zalb, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldZalba = _repository.GetZalbaById(zalb.ZalbaId);
                if (oldZalba == null)
                {
                    return NotFound();
                }
                Zalba zalbaEntity = _mapper.Map<Zalba>(zalb);
                _mapper.Map(zalbaEntity, oldZalba);
                _repository.SaveChanges();
                return Ok(_mapper.Map<ZalbaDTO>(oldZalba));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Brisanje žalbe
        /// </summary>
        /// <param name="zalbaId">Id žalbe</param>
        ///  <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer Katarina)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Žalba uspešno obrisana</response>
        /// <response code="401">Lice koje želi da izvrši brisanje žalbe nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena žalba za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja žalbe</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{zalbaId}")]
        public IActionResult DeleteZalba(Guid zalbaId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var zalb = _repository.GetZalbaById(zalbaId);
                if (zalb == null)
                {
                    return NotFound();
                }
                _repository.DeleteZalba(zalb.ZalbaID);
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
