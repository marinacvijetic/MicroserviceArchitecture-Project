using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// Klasa LicitacijaConfirmationDTO
    /// </summary>
    public class LicitacijaConfirmationDTO
    {

        /// <summary>
        /// broj licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezan broj licitacije")]
        public int brojLicitacije { get; set; }

        /// <summary>
        /// godina licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezana godina licitacije")]
        public int goidna { get; set; }

        /// <summary>
        /// datum licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum licitacije")]
        public DateTime datumLicitacije { get; set; }

        /// <summary>
        /// ogranicenje licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno ogranicenje licitacije")]
        public int ogranicenjeLicitacije { get; set; }

        /// <summary>
        /// korak cene licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezan korak cene")]
        public int korakCene { get; set; }

        /// <summary>
        /// rok za dostavu licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezan rok za prijavu")]
        public DateTime rokZaDostavuPrijava { get; set; }


    }
}
