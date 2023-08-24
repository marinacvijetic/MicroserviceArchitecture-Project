using AutoMapper;
using Dokument.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Dokument.Models.VerzijaDokumenta;
using Dokument.Entities;
using Dokument.Models.Dokument;
using Dokument.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dokument.Controllers
{
    [Route("api/verzije")]
    [ApiController]
    public class VerzijaDokumentaController : ControllerBase
    {
        private readonly IVerzijaDokumentaRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public VerzijaDokumentaController(IVerzijaDokumentaRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Prikaz svih verzija dokumenta
        /// </summary>
        /// <response code="200">Vraca sve verzije</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VerzijaDokumentaDTO>> GetAllVerzije()
        {
            Console.WriteLine("Getting verzije...");

            var verzijaItem = _repository.GetAllVerzije();

            return Ok(_mapper.Map<IEnumerable<VerzijaDokumentaDTO>>(verzijaItem));

        }

        /// <summary>
        /// Prikaz odredjene verzije dokumenta
        /// </summary>
        /// <param name="VerzijaID"></param>
        /// <response code="200">Vraca verziju sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji verzija sa prosledjenim ID-jem</response>
        [AllowAnonymous]
        [HttpGet("{VerzijaID}", Name = "GetVerzijaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<VerzijaDokumentaDTO> GetVerzijaById(Guid VerzijaID)
        {
            var verzijaItem = _repository.GetVerzijaById(VerzijaID);

            if (verzijaItem != null)
            {
                return Ok(_mapper.Map<VerzijaDokumentaDTO>(verzijaItem));
            }

            // Error 404
            return NotFound();
        }


        /// <summary>
        /// Kreiranje nove verzije
        /// </summary>
        /// <returns>Vraca novokreiranu verziju</returns>
        /// <response code="201">Vraca novokreiranu verziju</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<VerzijaDokumentaDTO> CreateVerzija(VerzijaDokumentaDTOCreate verzijaCreate, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var verzijaModel = _mapper.Map<VerzijaDokumentaEntity>(verzijaCreate);
                _repository.CreateVerzija(verzijaModel);
                _repository.SaveChanges();

                var verzijaDTO = _mapper.Map<VerzijaDokumentaDTO>(verzijaModel);

                return CreatedAtRoute("GetVerzijaById", new { ID = verzijaDTO.VerzijaID }, verzijaDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

            
        }



        /// <summary>
        /// Brisanje postojece verzije
        /// </summary>
        /// <param name="VerzijaID"></param>
        /// <response code="404">Ne postoji verzija sa tim ID-jem</response>
        /// <response code="200">Uspesno obrisana verzija</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{VerzijaID}")]
        public IActionResult DeleteVerzija(Guid VerzijaID, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var ver = _repository.GetVerzijaById(VerzijaID);
                if (ver == null)
                {
                    return NotFound();
                }
                _repository.DeleteVerzija(ver.VerzijaID);
                _repository.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

            
        }

        /// <summary>
        /// Izmena postojece verzije dokumenta
        /// </summary>
        /// <response code="200">Vraća ažuriranu verziju dokumenta</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađena verzija dokumenta za ažuriranje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<VerzijaDokumentaDTO> UpdateVerzija(VerzijaDokumentaDTOUpdate verzija, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldVerzija = _repository.GetVerzijaById(verzija.VerzijaID);
                if (oldVerzija == null)
                {
                    return NotFound();
                }
                VerzijaDokumentaEntity verzijaEntity = _mapper.Map<VerzijaDokumentaEntity>(verzija);
                _mapper.Map(verzijaEntity, oldVerzija);
                _repository.SaveChanges();
                return Ok(_mapper.Map<VerzijaDokumentaDTO>(oldVerzija));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

            
        }


    }
}
