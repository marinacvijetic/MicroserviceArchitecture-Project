using AutoMapper;
using Korisnici.Auth;
using Korisnici.Data.IRepo;
using Korisnici.Entities;
using Korisnici.Models.Korisnik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Korisnici.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisnikRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public KorisniciController(IKorisnikRepo repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        
        /// <summary>
        /// Prikaz svih korisnika
        /// </summary>
        /// <returns>Lista korisnika</returns>
        /// <response code="200">Vraca sve korisnike</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<KorisnikDTO>> GetAllKorisnici()
            {


            Console.WriteLine("Getting korisnici...");

            var korisnikItem = _repository.GetAllKorisnici();

            return Ok(_mapper.Map<IEnumerable<KorisnikDTO>>(korisnikItem));

            }

        /// <summary>
        /// Prikaz odredjenog korisnika
        /// </summary>
        /// <param name="KorisnikID"></param>
        /// <response code="200">Vraca korisnika sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji korisnik sa prosledjenim ID-jem</response>
        [AllowAnonymous]
        [HttpGet("{KorisnikID}", Name = "GetKorisnikById") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<KorisnikDTO> GetKorisnikById(int KorisnikID)
        {
            var korisnikItem = _repository.GetKorisnikById(KorisnikID);

            if (korisnikItem!= null)
            {
                return Ok(_mapper.Map<KorisnikDTO>(korisnikItem));
            }
            
            // 204
            return NoContent();
        }

        /// <summary>
        /// Kreiranje novog korisnika
        /// </summary>
        /// <returns>Vraca novokreiranog korisnika</returns>
        /// <response code="201">Vraca novokreiranog korisnika</response>
        /// /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<KorisnikDTO> CreateKorisnik(KorisnikDTOCreate korisnikCreate, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {

                var korisnikModel = _mapper.Map<KorisnikEntity>(korisnikCreate);
                _repository.CreateKorisnik(korisnikModel);
                _repository.SaveChanges();

                var korisnikDTO = _mapper.Map<KorisnikDTO>(korisnikModel);

                return CreatedAtRoute("GetKorisnikById", new { ID = korisnikDTO.KorisnikID }, korisnikDTO);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }


            
        }


        /// <summary>
        /// Brisanje postojeceg korisnika
        /// </summary>
        /// <param name="KorisnikID"></param>
        /// <response code="404">Ne postoji korisnik sa tim ID-jem</response>
        /// <response code="200">Uspesno obrisan korisnik</response>
        /// <response code="401">Korisnik nije autorizovan</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{KorisnikID}")]
        public IActionResult DeleteKorisnik(int KorisnikID, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var kor = _repository.GetKorisnikById(KorisnikID);
                if (kor == null)
                {
                    return NotFound();
                }
                _repository.DeleteKorisnik(kor.KorisnikID);
                _repository.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
          

            
        }

        /// <summary>
        /// Izmena postojeceg korisnika
        /// </summary>
        /// <response code="200">Vraća ažuriranog korisnika</response>
        /// <response code="401">Lice koje želi da izvrši ažuriranje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađen korisnik za ažuriranje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<KorisnikDTO> UpdateKorisnik(KorisnikDTOUpdate kor, [FromHeader(Name = "Authorization")] string key)
        {

            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }

            try
            {
                var oldKorisnik = _repository.GetKorisnikById(kor.KorisnikID);
                if (oldKorisnik == null)
                {
                    return NotFound();
                }
                KorisnikEntity korisnikEntity = _mapper.Map<KorisnikEntity>(kor);
                _mapper.Map(korisnikEntity, oldKorisnik);
                _repository.SaveChanges();
                return Ok(_mapper.Map<KorisnikDTO>(oldKorisnik));
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }


           
        }

    }
}
