using System.ComponentModel.DataAnnotations;
using System;

namespace KatastarskaOpstinaService.DTOs.CreationDto
{
    /// <summary>
    /// Predstavlja model katastarske opstine pri kreiranju.
    /// </summary>
    public class KatastarskaOpstinaCreationDto
    {
        /// <summary>
        /// ID statuta opstine
        /// </summary>
        public Guid StatutOpstineId { get; set; }

        /// <summary>
        /// Naziv opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv opstine")]
        public string NazivOpstine { get; set; }
    }
}
