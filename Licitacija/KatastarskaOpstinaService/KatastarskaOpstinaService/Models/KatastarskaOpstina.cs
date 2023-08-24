using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using KatastarskaOpstinaService.DTOs;

namespace KatastarskaOpstinaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet katastarske opstine.
    /// </summary>
    public class KatastarskaOpstina
    {
        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        [Key]
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Id statuta opstine
        /// </summary>
        [ForeignKey("StatutOpstine")]
        public Guid StatutOpstineId { get; set; }

        public StatutOpstine StatutOpstine { get; set; }
        /// <summary>
        /// Naziv opstine katastra
        /// </summary>
        public string NazivOpstine { get; set; }
        /// <summary>
        /// Parcele 
        /// </summary>
        [NotMapped]
        public List<ParcelaDto> Parcele { get; set; }
    }
}
