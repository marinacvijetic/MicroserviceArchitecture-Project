using System;

namespace KatastarskaOpstinaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet katastarske opstine za potvrdu.
    /// </summary>
    public class KatastarskaOpstinaConfirmation
    {
        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }
        
        /// <summary>
        /// Naziv opstine
        /// </summary>
        public string NazivOpstine { get; set; }
     
    }
}
