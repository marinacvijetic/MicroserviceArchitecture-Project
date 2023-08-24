using System.ComponentModel.DataAnnotations;
using System;


namespace ParcelaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet kvaliteta zemljista.
    /// </summary>
    public class KvalitetZemljista
    {
        /// <summary>
        /// Id kvalitet zemljista
        /// </summary>
        [Key]
        public Guid KvalitetZemljistaId { get; set; }

        /// <summary>
        /// Oznaka kvaliteta zemljista
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string OznakaKvaliteta { get; set; }

        /// <summary>
        /// Opis kvaliteta zemljista
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Opis { get; set; }
    }
}
