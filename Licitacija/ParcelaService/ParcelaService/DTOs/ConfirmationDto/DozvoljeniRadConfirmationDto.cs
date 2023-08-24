using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model dozvoljenog rada koji sluzi za potvrdu.
    /// </summary>
    public class DozvoljeniRadConfirmationDto
    {
        /// <summary>
        /// Id za dozvoljeni rad.
        /// </summary>
        public Guid DozvoljeniRadId { get; set; }
    }
}
