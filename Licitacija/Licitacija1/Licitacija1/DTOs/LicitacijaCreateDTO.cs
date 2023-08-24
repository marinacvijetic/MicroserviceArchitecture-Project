using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// Klasa LicitacijaCreateDTO
    /// </summary>
    public class LicitacijaCreateDTO
    {

 
        [Required(ErrorMessage = "Obavezan broj licitacije")]
        /// <summary>
        /// broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        [Required(ErrorMessage = "Obavezana godina licitacije")]
        /// <summary>
        /// godina licitacije
        /// </summary>
        public int godina { get; set; }
        [Required(ErrorMessage = "Obavezan datum licitacije")]
        /// <summary>
        /// datum licitacije
        /// </summary>
        public DateTime datumLicitacije { get; set; }
        [Required(ErrorMessage = "Obavezno ogranicenje licitacije")]
        /// <summary>
        /// ogranicenje licitacije
        /// </summary>
        public int ogranicenjeLicitacije { get; set; }
        [Required(ErrorMessage = "Obavezan korak cene")]
        /// <summary>
        /// korak cene licitacije
        /// </summary>
        public int korakCene { get; set; }
        [Required(ErrorMessage = "Obavezan rok za prijavu")]
        /// <summary>
        /// rok za dostavu licitacije
        /// </summary>
        public DateTime rokZaDostavuPrijava { get; set; }
    }
}
