using System;

namespace KatastarskaOpstinaService.DTOs.ConfirmationDto
{
    /// <summary>
    /// Predstavlja model katastarske opstine za potvrdu.
    /// </summary>
    public class KatastarskaOpstinaConfirmationDto
    {
        /// <summary>
        /// ID katastarske opstine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        public string NazivOpstine { get; set; }
    }
}
