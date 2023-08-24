using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model dela parcele koji sluzi za potvrdu.
    /// </summary>
    public class DeoParceleConfirmationDto
    {

        /// <summary>
        /// Id dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }
    }
}
