using System.ComponentModel.DataAnnotations;
using System;

namespace KatastarskaOpstinaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet statuta opstine.
    /// </summary>
    public class StatutOpstine
    {
        /// <summary>
        /// Id statuta opstine
        /// </summary>
        [Key]
        public Guid StatutOpstineId { get; set; }

        /// <summary>
        /// Sadrzaj statuta opstine.
        /// </summary>
        public string SadrzajStatuta { get; set; }

        /// <summary>
        /// Datum kreiranja statuta opstine.
        /// </summary>
        public DateTime DatumKreiranjaStatuta { get; set; }
  
    }
}
