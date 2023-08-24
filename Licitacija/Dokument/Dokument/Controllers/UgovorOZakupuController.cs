using AutoMapper;
using Dokument.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Dokument.Models.UgovorOZakupu;
using Dokument.Entities;
using Dokument.Models.Dokument;
using Dokument.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Dokument.Controllers
{
    [Route("api/ugovori")]
    [ApiController]
    public class UgovorOZakupuController : ControllerBase
    {

        private readonly IUgovorOZakupuRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public UgovorOZakupuController(IUgovorOZakupuRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;

        }

        /// <summary>
        /// Prikaz svih ugovora o zakupu
        /// </summary>
        /// <returns>Lista ugovora</returns>
        /// <response code="200">Vraca sve ugovore</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UgovorOZakupuDTO>> GetAllUgovori()
        {
            Console.WriteLine("Getting ugovori...");

            var ugovorItem = _repository.GetAllUgovori();

            return Ok(_mapper.Map<IEnumerable<UgovorOZakupuDTO>>(ugovorItem));

        }

        /// <summary>
        /// Prikaz odredjenog ugovora
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        /// <response code="200">Vraca ugovor sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji ugovor sa prosledjenim ID-jem</response>
        [AllowAnonymous]
        [HttpGet("{ugovorOZakupuID}", Name = "GetUgovorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<UgovorOZakupuDTO> GetUgovorById(Guid UgovorOZakupuID)
        {
            var ugovorItem = _repository.GetUgovorById(UgovorOZakupuID);

            if (ugovorItem != null)
            {
                return Ok(_mapper.Map<UgovorOZakupuDTO>(ugovorItem));
            }

            //204
            return NoContent();
        }

        /// <summary>
        /// Kreiranje novog ugovora
        /// </summary>
        /// <returns>Vraca novokreirani ugovor</returns>
        /// <response code="201">Vraca novokreirani ugovor</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<UgovorOZakupuDTO> CreateUgovor(UgovorOZakupuDTOCreate ugovorCreate, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var ugovorModel = _mapper.Map<UgovorOZakupuEntity>(ugovorCreate);
                _repository.CreateUgovor(ugovorModel);
                _repository.SaveChanges();

                var ugovorOZakupuDTO = _mapper.Map<UgovorOZakupuDTO>(ugovorModel);

                return CreatedAtRoute("GetUgovorById", new { ID = ugovorOZakupuDTO.UgovorOZakupuID }, ugovorOZakupuDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }



        }

        /// <summary>
        /// Brisanje postojeceg ugovora
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        /// <response code="404">Ne postoji ugovor sa tim ID-jem</response>
        /// <response code="200">Uspesno obrisan ugovor</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{UgovorOZakupuID}")]
        public IActionResult DeleteUgovor(Guid UgovorOZakupuID, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var ver = _repository.GetUgovorById(UgovorOZakupuID);
                if (ver == null)
                {
                    return NotFound();
                }
                _repository.DeleteUgovor(ver.UgovorOZakupuID);
                _repository.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }



        }

        /// <summary>
        /// Izmena postojeceg ugovora
        /// </summary>
        ///    /// <summary>
        /// Izmena postojeceg dokumenta
        /// </summary>
        /// /// <summary>
        /// Izmena postojeceg korisnika
        /// </summary>
        /// <response code="200">Vraća ažurirani ugovor</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen ugovor za ažuriranje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<UgovorOZakupuDTO> UpdateUgovor(UgovorOZakupuDTOUpdate ugovor, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldUgovor = _repository.GetUgovorById(ugovor.UgovorOZakupuID);
                if (oldUgovor == null)
                {
                    return NotFound();
                }
                UgovorOZakupuEntity ugovorEntity = _mapper.Map<UgovorOZakupuEntity>(ugovor);
                _mapper.Map(ugovorEntity, oldUgovor);
                _repository.SaveChanges();
                return Ok(_mapper.Map<UgovorOZakupuDTO>(oldUgovor));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }


        }




    }
}
