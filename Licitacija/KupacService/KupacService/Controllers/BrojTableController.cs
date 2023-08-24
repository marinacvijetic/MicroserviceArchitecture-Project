using AutoMapper;
using KupacService.Data.Interfaces;
using KupacService.Models.Kupac;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using KupacService.Models.BrojTable;
using KupacService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using KupacService.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler za Broj Table koji omogucava CRUD operacije.
    /// </summary>
    [Produces("application/json", "application/xml")]
    [Route("api/brojTable")]
    [ApiController]
    [Authorize]
    public class BrojTableController : ControllerBase
    {
        private readonly IBrojTableRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        /// <summary>
        /// Instanciranje neophodnih komponenti. 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="authHelper"></param>
        public BrojTableController(IBrojTableRepository repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraća sve brojeve table.
        /// </summary>
        /// <returns>Lista brojeva tabla nadmetanja</returns>
        /// <response code="200">Vraća listu brojeva</response>
        /// <response code="404">Nije pronađen ni jedan broj table.</response>
        [HttpGet]
        [HttpHead] //Podržavamo i HTTP head zahtev koji nam vraća samo zaglavlja u odgovoru    
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BrojTableDTO>> GetBrojeviTabla()
        {
            var tableItems = _repository.GetAllBrojeviTabla();

            return Ok(_mapper.Map<IEnumerable<BrojTableDTO>>(tableItems));
        }

        /// <summary>
        /// Vraća jedan broj table na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID Broja table</param>
        /// <returns>Vraća jedan konkretan broj</returns>
        /// <response code="200">Vraća traženi broj table</response>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}", Name = "GetBrojTableByID")]
        public ActionResult<BrojTableDTO> GetBrojTableByID(Guid id)
        {
            var tablaItem = _repository.GetBrojTableByID(id);
            if (tablaItem != null)
            {
                return Ok(_mapper.Map<BrojTableDTO>(tablaItem));
            }

            return NotFound();
        }

        /// <summary>
        /// Kreira novi broj table.
        /// </summary>
        /// <param name="tablaItem">Model broja table</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o kreiranom broju table.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog broja table \
        /// POST /api/brojTable \
        /// {     \
        ///     "BrojTableID": "2841defc-761e-40d8-b8a3-d3e58516dca7", \
        ///     "Broj": "12", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirani broj table</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<BrojTableDTO> CreateBrojTable(BrojTableDTO tablaItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                //Prosledjen je dto, ali repository radi sa entitetima
                //Zato se prvo vrsi mapiranje kako bi se kreirao privremeni entitet koji ce biti prosledjen u repository
                var tablaModel = _mapper.Map<BrojTable>(tablaItem);
                _repository.CreateBrojTable(tablaModel);
                _repository.SaveChanges();

                //Mapiranje modela nazad u dto
                var tablaDto = _mapper.Map<BrojTableDTO>(tablaModel);

                return CreatedAtRoute("GetBrojTableByID", new { ID = tablaModel.BrojTableID }, tablaDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
            
        }

        /// <summary>
        /// Ažurira jedan broj table.
        /// </summary>
        /// <param name="tablaItem">Model broja table</param>
        /// <param name="key"></param>
        /// <returns>Potvrdu o modifikovanom broju table.</returns>
        /// <response code="200">Vraća ažuriran broj table</response>
        /// <response code="400">Broj table koji se ažurira nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja broja table</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<BrojTableDTO> UpdateBrojTable(BrojTableDTO tablaItem, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var tablaModel = _mapper.Map<BrojTable>(tablaItem);

                if (tablaModel != null)
                {
                    _repository.UpdateBrojTable(tablaModel);
                    _repository.SaveChanges();

                    var tablaDto = _mapper.Map<BrojTableDTO>(tablaModel);
                    return Ok(tablaDto);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }


        }

        /// <summary>
        /// Vrši brisanje jednog broja table na osnovu ID-ja broja table.
        /// </summary>
        /// <param name="id">ID broja table</param>
        /// <param name="key"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Broj table nije uspešno obrisan</response>
        /// <response code="404">Nije pronađen broj table</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja broja table</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteBrojTable(Guid id, [FromHeader(Name ="Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                _repository.DeleteBrojTable(id);
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
