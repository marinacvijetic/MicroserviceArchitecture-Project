using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// klasa LicitacijaUpdateDTO
    /// </summary>
    public class LicitacijaUpdateDTO
    {
        [Required]
        /// <summary>
        /// Identifikator licitacije
        /// </summary>
        public Guid LicitacijaID { get; set; }
        [Required]
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        [Required]
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int godina { get; set; }
        [Required]
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public DateTime datumLicitacije { get; set; }
        [Required]
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int ogranicenjeLicitacije { get; set; }
        [Required]
        /// <summary>
        /// Korak cene
        /// </summary>
        public int korakCene { get; set; }
        [Required]
        /// <summary>
        /// Rok za dostavljanje dokumenata za prijavu
        /// </summary>
        public DateTime rokZaDostavuPrijava { get; set; }
        
    }
}
