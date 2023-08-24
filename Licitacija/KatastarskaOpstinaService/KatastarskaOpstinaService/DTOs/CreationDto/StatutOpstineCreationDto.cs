using System;

namespace KatastarskaOpstinaService.DTOs.CreationDto
{
    /// <summary>
    /// Predstavlja model statuta opstine pri kreiranju.
    /// </summary>
    public class StatutOpstineCreationDto
    {
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
