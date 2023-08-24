using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs
{
    /// <summary>
    /// Predstavlja model zasticene zone.
    /// </summary>
    public class ZasticenaZonaDto
    {
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Broj zasticene zone
        /// </summary>
        public int BrojZasticeneZone { get; set; }
    }
}
