using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Entities.Confirmations
{
    /// <summary>
    /// Predstavlja realni entitet parcele za potvrdu.
    /// </summary>
    public class ParcelaConfirmation
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        public Guid ParcelaId { get; set; }
    }
}
