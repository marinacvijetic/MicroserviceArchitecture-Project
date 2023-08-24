using System.Collections.Generic;
using System;

namespace KatastarskaOpstinaService.DTOs
{
    /// <summary>
    /// Predstavlja model katastarske opstine.
    /// </summary>
    public class KatastarskaOpstinaDto
    {

        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }
     
        /// <summary>
        /// Parcela
        /// </summary>
        public List<ParcelaDto> Parcele { get; set; }
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
