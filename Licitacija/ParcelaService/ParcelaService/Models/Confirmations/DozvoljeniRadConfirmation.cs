using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Entities.Confirmations
{
    /// <summary>
    /// Predstavlja realni entitet dozvoljenog rada za potvrdu.
    /// </summary>
    public class DozvoljeniRadConfirmation
    {
        /// <summary>
        /// Id dozvoljenog rada
        /// </summary>
        public Guid DozvoljeniRadId { get; set; }
    }
}
