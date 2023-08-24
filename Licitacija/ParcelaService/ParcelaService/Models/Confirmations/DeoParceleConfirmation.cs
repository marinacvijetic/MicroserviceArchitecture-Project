using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Entities.Confirmations
{
    /// <summary>
    /// Predstavlja realni entitet dela parcele za potvrdu.
    /// </summary>
    public class DeoParceleConfirmation
    {
        /// <summary>
        /// Id dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }
    }
}
