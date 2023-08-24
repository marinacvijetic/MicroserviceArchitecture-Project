using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model dozvoljenog rada koji se koristi prilikom azuriranja podataka.
    /// </summary>
    public class DozvoljeniRadUpdateDto
    {
        /// <summary>
        /// Id dozvoljenog rada.
        /// </summary>
        public Guid DozvoljeniRadId { get; set; }

        /// <summary>
        /// Opis dozvoljenog rada.
        /// </summary>
        public string Opis { get; set; }

        /// <summary>
        /// Id zasticene zone.
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }
    }
}
