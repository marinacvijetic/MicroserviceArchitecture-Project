using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model zasticene zone koji se koristi prilikom azuriranja podataka.
    /// </summary>
    public class ZasticenaZonaUpdateDto
    {
        /// <summary>
        /// Id zasticene zone.
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Broj zasticene zone.
        /// </summary>
        public int BrojZasticeneZone { get; set; }
    }
}
