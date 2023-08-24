using AutoMapper;
using Licitacija1.Auth;
using Licitacija1.Data;
using Licitacija1.DTOs;
using Licitacija1.Entities;
using Licitacija1.SyncDataServices.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Controllers
{
    [ApiController]
    [Route("api/licitacije")]
    public class LicitacijaContoller : ControllerBase
    {
        private readonly ILicitacijaRepository licitacija;
        private readonly ILicitacijaDokumentRepository _dokumentRepo;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        private readonly IJavnoNadmetanjeDataClient _javnoNadmetanjeDataClient;


        public LicitacijaContoller(ILicitacijaRepository licitacijaRepository, ILicitacijaDokumentRepository dokumentRepo,IMapper mapper,
          IJavnoNadmetanjeDataClient javnoNadmetanjeDataClient,  IAuthHelper authHelper)
        {
            licitacija = licitacijaRepository;
            _mapper = mapper;
            _authHelper = authHelper;
            _javnoNadmetanjeDataClient = javnoNadmetanjeDataClient;
            _dokumentRepo = dokumentRepo;
        }

        /// <summary>
        /// Vraca listu licitacija
        /// </summary>
        /// <returns>Lista svih licitacija</returns>
        /// <remarks> 
        /// Primer request-a \
        /// GET 'https://localhost:4001/api/licitacije' \
        /// </remarks>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<LicitacijaDTO>> GetLicitacije()
        {
            Console.WriteLine("Getting licitacije...");

            var licitacije = licitacija.GetLicitacije();
            foreach (LicitacijaModel l in licitacije)
            {
                
                List<DokumentModel> pravniDokumenti = _dokumentRepo.GetDokumentByLicitacijaID(l.licitacijaID);
                l.dokumenti = pravniDokumenti;
                List<JavnoNadmetanjeDTO> javnaNadmetanja = _javnoNadmetanjeDataClient.GetJavnaNadmetanjaByLicitacijaID().Result;
                l.javnaNadmetanja = javnaNadmetanja;
                _mapper.Map<List<JavnoNadmetanjeDTO>>(javnaNadmetanja);
                _mapper.Map<IEnumerable<DokumentModel>>(pravniDokumenti);
            }
   

            return Ok(_mapper.Map<IEnumerable<LicitacijaDTO>>(licitacije));
        }

        /// <summary>
        /// Vraca licitaciju sa specificiranim licitacijaID
        /// </summary>
        /// <param name="ID">Jedinstevni identifikator licitacije</param>
        /// <remarks>    
        /// Primer request-a \
        /// GET 'https://localhost:4001/api/licitacije/' \
        ///     --param  'ID = dace9578-f369-4490-adbd-08db10e87c12'
        /// </remarks>
        [AllowAnonymous]
        [HttpGet("{licitacijaID}", Name="GetLicitacijaByID")]
        public ActionResult<LicitacijaDTO> GetLicitacijaByID(Guid licitacijaID)
        {
            Console.WriteLine("Getting licitacije...");

            var licitatcijaItem = licitacija.GetLicitacijaByID(licitacijaID);

            if (licitatcijaItem != null)
            {
                return Ok(_mapper.Map<LicitacijaDTO>(licitatcijaItem));
            }   
            return NotFound();
        }

        /// <summary>
        /// Pravi novu licitaciju
        /// </summary>
        /// <param name="licitacijaCreateDTO">Model licitacije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Primer request-a \
        /// PUT 'https://localhost:4001/api/licitacije/'\
        ///  --header 'key: Bearer Nikola' \
        /// Example: \
        /// { \
        ///         licitacijaID = "a0045e28-fe2c-443c-6855-08db110df141"
        ///         brojLicitacije = 1,
        ///          goidna = 2019,
        ///          ogranicenjeLicitacije = 1,
        ///          korakCene = 1,
        ///          datumLicitacije = "2019-01-02",
        ///          rokZaDostavuPrijava = "2019-02-22"
        /// } \
        /// </remarks>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<LicitacijaDTO> CreateLicitacija(LicitacijaCreateDTO licitacijaCreateDTO, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var licitacijaModel = _mapper.Map<LicitacijaModel>(licitacijaCreateDTO);
                licitacija.CreateLicitacija(licitacijaModel);
                licitacija.SaveChanges();

                var licitacijaDTO = _mapper.Map<LicitacijaDTO>(licitacijaModel);

                return CreatedAtRoute(nameof(GetLicitacijaByID), new { licitacijaID = licitacijaDTO.LicitacijaID }, licitacijaDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }


        }
        /// <summary>
        /// Vrsi azuriranje licitacije
        /// </summary>
        /// <param name="licit">Model licitacije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Primer request-a \
        /// PUT 'https://localhost:4001/api/licitacije/'\
        ///  --header 'key: Bearer Nikola' \
        /// Example: \
        /// { \
        ///         licitacijaID = "a0045e28-fe2c-443c-6855-08db110df141"
        ///         brojLicitacije = 1,
        ///          goidna = 2019,
        ///          ogranicenjeLicitacije = 1,
        ///          korakCene = 1,
        ///          datumLicitacije = "2019-01-02",
        ///          rokZaDostavuPrijava = "2019-02-22"
        /// } \
        /// </remarks>

        [HttpPut]
        public ActionResult<LicitacijaDTO> UpdateLicitacija(LicitacijaUpdateDTO licit , [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldLicitacija = licitacija.GetLicitacijaByID(licit.LicitacijaID);
                if (oldLicitacija == null)
                {
                    return NotFound();
                }
                LicitacijaModel licitacijaEntity = _mapper.Map<LicitacijaModel>(licit);
                _mapper.Map(licitacijaEntity, oldLicitacija);
                licitacija.SaveChanges();
                return Ok(_mapper.Map<LicitacijaDTO>(oldLicitacija));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
            
        }
        /// <summary>
        /// Obrisi licitaciju
        /// </summary>
        /// <param name="licitacijaID">Jedinstevni identifikator liictacije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <remarks>
        /// Example of request \
        /// DELETE 'https://localhost:4001/api/licitacije/'\
        ///  --header 'key: Bearer Nikola' \
        ///  --param  'licitacijaID = a0045e28-fe2c-443c-6855-08db110df141'\
        /// </remarks>
        [HttpDelete("{licitacijaID}")]
        public IActionResult DeleteLicitacija(Guid licitacijaID, [FromHeader(Name = "Authorization")] string key)
        {
          
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var licit = licitacija.GetLicitacijaByID(licitacijaID);
                if (licit == null)
                {
                    return NotFound();
                }
                licitacija.DeleteLicitacija(licit.licitacijaID);
                licitacija.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }
       
    }

}
