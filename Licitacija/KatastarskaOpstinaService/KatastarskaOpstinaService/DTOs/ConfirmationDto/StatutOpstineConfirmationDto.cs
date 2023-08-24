using System;

namespace KatastarskaOpstinaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model statuta opstine za potvrdu.
    /// </summary>
    public class StatutOpstineConfirmationDto
    {
        /// <summary>
        /// ID statuta opstine
        /// </summary>
        public Guid StatutOpstineId { get; set; }

        /// <summary>
        /// Sadrzaj statuta opstine
        /// </summary>
        public string SadrzajStatuta { get; set; }

    }
}
