using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ParcelaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet dozvoljenog rada.
    /// </summary>
    public class DozvoljeniRad
    {
        /// <summary>
        /// Id dozvoljenog rada
        /// </summary>
        [Key]
        public Guid DozvoljeniRadId { get; set; }

        /// <summary>
        /// Opis dozvoljenog rada
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Opis { get; set; }

        /// <summary>
        /// Strani kljuc zasticene zone
        /// </summary>
        [ForeignKey("ZasticenaZona")]
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Zasticena zona entitet
        /// </summary>
        public ZasticenaZona ZasticenaZona { get; set; }
    }
}
