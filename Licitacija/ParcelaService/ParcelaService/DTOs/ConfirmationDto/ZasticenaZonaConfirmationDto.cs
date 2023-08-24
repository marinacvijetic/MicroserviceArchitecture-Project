using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model zasticene zone koji sluzi za potvrdu.
    /// </summary>
    public class ZasticenaZonaConfirmationDto
    {
        /// <summary>
        /// Id zasticene zone.
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }
    }
}
