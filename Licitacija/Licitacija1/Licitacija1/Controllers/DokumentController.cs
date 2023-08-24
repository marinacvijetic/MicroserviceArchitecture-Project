using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licitacija1.Data;
using Licitacija1.DTOs;
using Licitacija1.Entities;
using Licitacija1.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Licitacija1.Controllers
{
    [ApiController]
    [Route("api/dokumenti")]
    public class DokumentController : ControllerBase
    {
        private readonly ILicitacijaDokumentRepository _dokumentRepo;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dokumentRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public DokumentController(ILicitacijaDokumentRepository dokumentRepository, IMapper mapper, IAuthHelper authHelper)
        {
            _dokumentRepo = dokumentRepository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca listu dokumenata
        /// </summary>
        /// <returns>Lista svih dokumenata</returns>
        /// <remarks> 
        /// Primer request-a \
        /// GET 'https://localhost:4001/api/dokumenti' \
        /// </remarks>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DokumentDTO>> GetDokumenti()
        {

            var dokumenti = _dokumentRepo.GetDokumenti();

            return Ok(_mapper.Map<IEnumerable<DokumentDTO>>(dokumenti));
        }


        /// <summary>
        /// Vraca dokument sa specificiranim ID
        /// </summary>
        /// <param name="ID">Jedinstevni identifikator dokumenta</param>
        /// <remarks>    
        /// Primer request-a \
        /// GET 'https://localhost:4001/api/dokumenti/' \
        ///     --param  'ID = 4f7c7ecd-49e7-4c39-8840-273954346524'
        /// </remarks>
        [HttpGet("{dokumentID}", Name="GetDokumentByID")]
        [AllowAnonymous]
        public ActionResult<DokumentDTO> GetDokumentByID(Guid dokumentID)
        {
           

            var dokument = _dokumentRepo.GetDokumentByID(dokumentID);

            if (dokument != null)
            {
                return Ok(_mapper.Map<DokumentDTO>(dokument));
            }
            return NotFound();
        }


        /// <summary>
        /// Vraca dokumenta sa specificiranim  ID-em Licitacije
        /// </summary>
        /// <param name="ID">Jedinstevni identifikator licitacije</param>
        /// <remarks>    
        /// Primer request-a \
        /// GET 'https://localhost:4001/' \
        ///     --param  'ID = 3c5a441b-2ed4-4012-8377-6660b1994895'
        /// </remarks>

        [HttpGet("/{dokumentID}", Name = "GetDokumentByLicitacijaID")]
        public ActionResult<List<DokumentDTO>> GetDokumentByLicitacijaID(Guid dokumentID)
        {


            var dokument = _dokumentRepo.GetDokumentByLicitacijaID(dokumentID);

            return Ok(_mapper.Map<List<DokumentDTO>>(dokument));
        }


        /// <summary>
        /// Pravi novi dokument
        /// </summary>
        /// <param name="dokumentCreateDTO">Model licitacije i dokumenta</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Primer request-a \
        /// POST 'https://localhost:4001/api/dokumenti'\
        ///     --header 'key: Bearer Nikola' \
        /// Example: \
        /// { \
        ///          licitacijaId = 3c5a441b-2ed4-4012-8377-6660b1994895,
        ///          "datum": "0001-01-01T00:00:00",
        ///          vrstaPodnosiocaDokumenta = "F",
        ///          NazivDokumenta = "Dokument1"
        ///}
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<DokumentDTO> CreateDokument(DokumentCreateDTO dokumentCreateDTO, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var dokument = _mapper.Map<DokumentModel>(dokumentCreateDTO);
                _dokumentRepo.CreateLicitacijaDokument(dokument);
                _dokumentRepo.SaveChanges();

                var dokumentDTO = _mapper.Map<DokumentDTO>(dokument);

                return CreatedAtRoute(nameof(GetDokumentByID), new { dokumentID = dokumentDTO.dokumentID }, dokumentDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }

        }


        /// <summary>
        /// Vrsi azuriranje dokumenta
        /// </summary>
        /// <param name="dokument">Model licitacije i dokumenta</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Primer request-a \
        /// POST 'https://localhost:4001/api/dokumenti'\
        ///     --header 'key: Bearer Nikola' \
        /// Example: \
        /// { \
        ///           "dokumentID": "1fcfb688-05ca-4304-8cd3-df3f79b8aeb6",
        ///          licitacijaId = 6de0c4ee-8870-4649-a44b-921e5a7b2644,
        ///          "datum": "0001-01-01T00:00:00",
        ///          vrstaPodnosiocaDokumenta = "F",
        ///          NazivDokumenta = "Dokument1"
        ///}
        /// </remarks>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<DokumentDTO> UpdateLicitacijaDokument(DokumentUpdateDTO dokument, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldDokument = _dokumentRepo.GetDokumentByID(dokument.dokumentId);
                if (oldDokument == null)
                {
                    return NotFound();
                }
                DokumentModel dokumentEntity = _mapper.Map<DokumentModel>(dokument);
                _mapper.Map(dokumentEntity, oldDokument);
                _dokumentRepo.SaveChanges();
                return Ok(_mapper.Map<DokumentDTO>(oldDokument));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Obrisi dokument
        /// </summary>
        /// <param name="dokumentID">Jedinstevni identifikator dokuenta</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Example of request \
        /// DELETE 'https://localhost:4001/api/dokumenti/'\
        ///  --header 'key: Bearer Nikola' \
        ///  --param  'dokumentID = 1fcfb688-05ca-4304-8cd3-df3f79b8aeb6'\
        /// </remarks>
        [HttpDelete("{dokumentID}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(Guid dokumentID, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var dokument = _dokumentRepo.GetDokumentByID(dokumentID);
                if (dokument == null)
                {
                    return NotFound();
                }
                _dokumentRepo.Delete(dokument.dokumentID);
                _dokumentRepo.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
            
        }
    }
}
