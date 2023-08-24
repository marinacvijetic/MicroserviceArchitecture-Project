using AutoMapper;
using Dokument.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Dokument.Models.Dokument;
using Dokument.Entities;
using Dokument.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dokument.Controllers
{
    [Route("api/dokumenti")]
    [ApiController]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public DokumentController(IDokumentRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Prikaz svih dokumenata
        /// </summary>
        /// <returns>Lista dokumenata</returns>
        /// <response code="200">Vraca sve dokumente</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DokumentDTO>> GetAllDokumenti()
        {
            Console.WriteLine("Getting dokumenti...");

            var dokumentItem = _repository.GetAllDokumenti();

            return Ok(_mapper.Map<IEnumerable<DokumentDTO>>(dokumentItem));

        }

        /// <summary>
        /// Prikaz odredjenog dokumenta
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <response code="200">Vraca dokument sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji dokument sa prosledjenim ID-jem</response>
        [AllowAnonymous]
        [HttpGet("{DokumentID}", Name = "GetDokumentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<DokumentDTO> GetDokumentById(int DokumentID)
        {
            var dokumentItem = _repository.GetDokumentById(DokumentID);

            if (dokumentItem != null)
            {
                return Ok(_mapper.Map<DokumentDTO>(dokumentItem));
            }

            // 204
            return NoContent();
        }


        /// <summary>
        /// Kreiranje novog dokumenta
        /// </summary>
        /// <returns>Vraca novokreirani dokument</returns>
        /// <response code="201">Vraca novokreirani dokument</response>
        /// <response code="401">Korisnik nije autorizovan</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<DokumentDTO> CreateKorisnik(DokumentDTOCreate dokumentCreate, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var dokumentModel = _mapper.Map<DokumentEntity>(dokumentCreate);
                _repository.CreateDokument(dokumentModel);
                _repository.SaveChanges();

                var dokumentDTO = _mapper.Map<DokumentDTO>(dokumentModel);

                return CreatedAtRoute("GetDokumentById", new { ID = dokumentDTO.DokumentID }, dokumentDTO);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
           
        }

        /// <summary>
        /// Izmena postojeceg dokumenta
        /// </summary>
        /// /// <summary>
        /// Izmena postojeceg korisnika
        /// </summary>
        /// <response code="200">Vraća ažurirani dokument</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen dokument za ažuriranje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<DokumentDTO> UpdateDokument(DokumentDTOUpdate dok, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldDokument = _repository.GetDokumentById(dok.DokumentID);
                if (oldDokument == null)
                {
                    return NotFound();
                }
                DokumentEntity dokumentEntity = _mapper.Map<DokumentEntity>(dok);
                _mapper.Map(dokumentEntity, oldDokument);
                _repository.SaveChanges();
                return Ok(_mapper.Map<DokumentDTO>(oldDokument));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }


        }

        /// <summary>
        /// Brisanje postojeceg dokumenta
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <response code="404">Ne postoji dokument sa tim ID-jem</response>
        /// <response code="200">Uspesno obrisan dokument</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{DokumentID}")]
        public IActionResult DeleteDokument(int DokumentID, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {

                var dok = _repository.GetDokumentById(DokumentID);
                if (dok == null)
                {
                    return NotFound();
                }
                _repository.DeleteDokument(dok.DokumentID);
                _repository.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }



        }
    }
}
