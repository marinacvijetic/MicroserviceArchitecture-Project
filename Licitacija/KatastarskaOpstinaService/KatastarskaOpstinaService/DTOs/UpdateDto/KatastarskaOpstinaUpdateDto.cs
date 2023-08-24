using System.Collections.Generic;
using System;

namespace KatastarskaOpstinaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model katastarske opstine za azuriranje.
    /// </summary>
    public class KatastarskaOpstinaUpdateDto
    {
        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }
                
        /// <summary>
        /// ID statuta opstine
        /// </summary>
        public Guid StatutOpstineId { get; set; }

        /// <summary>
        /// Naziv opstine
        /// </summary>
        public string NazivOpstine { get; set; }
    }
}
