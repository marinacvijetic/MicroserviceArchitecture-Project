using System;

namespace KatastarskaOpstinaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet statuta opstine za potvrdu.
    /// </summary>
    public class StatutOpstineConfirmation
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
