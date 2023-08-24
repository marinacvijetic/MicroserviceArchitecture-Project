using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model kvaliteta zemljista koji sluzi za potvrdu.
    /// </summary>
    public class KvalitetZemljistaConfirmationDto
    {
        /// <summary>
        /// Id kvaliteta zemljista.
        /// </summary>
        public Guid KvalitetZemljistaId { get; set; }
    }
}
