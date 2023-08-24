using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Entities.Confirmations
{
    /// <summary>
    /// Predstavlja realni entitet zasticene zone za potvrdu.
    /// </summary>
    public class ZasticenaZonaConfirmation
    {
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }
    }
}
