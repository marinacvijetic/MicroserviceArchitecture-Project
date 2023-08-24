using System;

namespace KatastarskaOpstinaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model statuta opstine za azuriranje.
    /// </summary>
    public class StatutOpstineUpdateDto
    {
        /// <summary>
        /// Id statuta opstine
        /// </summary>
        public Guid StatutOpstineId { get; set; }

        /// <summary>
        /// Sadrzaj statuta opstine
        /// </summary>
        public string SadrzajStatuta { get; set; }

        /// <summary>
        /// Datum kreiranja statuta opstine
        /// </summary>
        public DateTime DatumKreiranjaStatuta { get; set; }
    }
}
