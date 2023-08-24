using AutoMapper;
using KatastarskaOpstinaService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using KatastarskaOpstinaService.DTOs;
using KatastarskaOpstinaService.DTOs.CreationDto;
using KatastarskaOpstinaService.Models;
using KatastarskaOpstinaService.DTOs.ConfirmationDto;
using KatastarskaOpstinaService.DTOs.UpdateDto;
using KatastarskaOpstinaService.SyncDataServices.http;
using System.Threading.Tasks;
using System.Linq;
using KatastarskaOpstinaService.Auth;
using Microsoft.AspNetCore.Http;

namespace KatastarskaOpstinaService.Controllers
{
    [ApiController]
    [Route("api/katastarskaOpstina")]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepo _repository;
        private readonly IMapper _mapper;
        private readonly IParcelaDataClient _parcelaDataClient;
        private readonly IAuthHelper _authHelper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepo repository, IMapper mapper, IParcelaDataClient parcelaDataClient, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _parcelaDataClient = parcelaDataClient;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca sve katastarske opstine
        /// </summary>
        /// <returns>Lista katastarskih opstina</returns>
        /// <response code= "200">Vraca listu katastarskih opstina</response>
        /// <response code= "204">Ne postoji nijedna katastarska opstina</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<KatastarskaOpstinaDto>> GetAll()
        {
            Console.WriteLine("-->getting katastarske opstine");

            var katastarskaOpstinaItems = _repository.GetAll();
            if (katastarskaOpstinaItems ==null || !katastarskaOpstinaItems.Any())
            {
                return NoContent();
            }
            foreach(var ko in katastarskaOpstinaItems)
            {
                ko.Parcele = _parcelaDataClient.GetParcelaForKatastarskaOpstina(ko.KatastarskaOpstinaId).Result;
            }
            
            return Ok(_mapper.Map<IEnumerable<KatastarskaOpstinaDto>>(katastarskaOpstinaItems));
        }

        /// <summary>
        /// Vraca katastarsku opstinu po ID-u
        /// </summary>
        /// <param name="katastarskaOpstinaId">ID katastarske opstine</param>
        /// <returns>Odgovarajuca katastarska opstina</returns>
        /// <response code= "200">Vraca trazenu katastarsku opstina</response>
        /// <response code= "204">Nije pronadjena trazena katastarska opstina</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{katastarskaOpstinaId}", Name = "GetKatastarskaOpstinaById")]
        [AllowAnonymous]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            var katastarskaOpstinaItem = _repository.GetById(katastarskaOpstinaId);
            if (katastarskaOpstinaItem != null)
            {
                katastarskaOpstinaItem.Parcele = _parcelaDataClient.GetParcelaForKatastarskaOpstina(katastarskaOpstinaItem.KatastarskaOpstinaId).Result;
                
                return Ok(_mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstinaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreiranje nove katastarske opstine
        /// </summary>
        /// <param name="katastarskaOpstinaCreationDto">Model katastarske opstine </param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija Bearer AnaMarija</param>
        /// <returns>Potvrda o kreiranju katastarske opstine</returns>
        /// <response code= "201">Vraca kreiranu katastarsku opstina</response>
        /// <response code= "401">Lice koje zeli da izvrsi kreiranje katastarske opstine nije autorizovani korisnik</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom kreiranja katastarske opstine</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<KatastarskaOpstinaDto> CreateKatastarskaOpstina(KatastarskaOpstinaCreationDto katastarskaOpstinaCreationDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var katOpstModel = _mapper.Map<KatastarskaOpstina>(katastarskaOpstinaCreationDto);
                _repository.Create(katOpstModel);
                _repository.SaveChanges();

                var katastarskaOpstinaDto = _mapper.Map<KatastarskaOpstinaDto>(katOpstModel);

                return CreatedAtRoute(nameof(GetKatastarskaOpstinaById), new { KatastarskaOpstinaId = katastarskaOpstinaDto.KatastarskaOpstinaId }, katastarskaOpstinaDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Azuriranje ugovora
        /// </summary>
        /// <param name="katOpst">Model katastarske opstine</param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija Bearer AnaMarija</param>
        /// <returns>Potvrda u izmenama u katastarskoj opstini</returns>
        /// <response code= "200">Katastarska opstina azurirana</response>
        /// <response code= "401">Lice koje zeli da izvrsi brisanje katastarske opstine nije autorizovani korisnik</response>
        /// <response code= "404">Nije pronadjena katastarska opstina za brisanje</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom brisanja katastarske opstine</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<KatastarskaOpstinaCreationDto> Update(KatastarskaOpstinaUpdateDto katOpst, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldKatOpst = _repository.GetById(katOpst.KatastarskaOpstinaId);
                if (oldKatOpst == null)
                {
                    return NotFound();
                }
                KatastarskaOpstina katOpstEntity = _mapper.Map<KatastarskaOpstina>(katOpst);
                _mapper.Map(katOpstEntity, oldKatOpst);
                _repository.SaveChanges();
                return Ok(_mapper.Map<KatastarskaOpstinaDto>(oldKatOpst));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Brisanje ugovora
        /// </summary>
        /// <param name="katastarskaOpstinaId">ID katastarske opstine</param>
        /// <param name="key">Kljuc sa kojim se proverava autorizacija Bearer AnaMarija</param>
        /// <returns>Status 204(NoContent)</returns>
        /// <response code= "204">Katastarska opstina uspesno obrisana</response>
        /// <response code= "401">Lice koje zeli da izvrsi brisanje katastarske opstine nije autorizovani korisnik</response>
        /// <response code= "404">Nije pronadjena katastarska opstina za brisanje</response>
        /// <response code= "500">Doslo je do greske na serveru prilikom brisanja katastarske opstine</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{katastarskaOpstinaId}")]
        public IActionResult Delete(Guid katastarskaOpstinaId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var katOpst = _repository.GetById(katastarskaOpstinaId);
                if (katOpst == null)
                {
                    return NotFound();
                }
                _repository.Delete(katastarskaOpstinaId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa katastarskim opstinama
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKatastarskaOpstinaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
