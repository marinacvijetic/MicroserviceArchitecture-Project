using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model parcele koji sluzi za potvrdu.
    /// </summary>
    public class ParcelaConfirmationDto
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        public Guid ParcelaId { get; set; }
    }
}
