using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// Klasa DokumentCreateDTO
    /// </summary>
    public class DokumentCreateDTO
    {
        /// <summary>
        /// Identifikator licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezan identifikator licitacije")]
        public Guid licitacijaId { get; set; }

        /// <summary>
        /// Identifikator dokumenta
        /// </summary>
        [Required(ErrorMessage = "Obavezan identifikator dokumenta")]
        public Guid dokumentId { get; set; }
        /// <summary>
        /// naziv dokumenta
        /// </summary>
        public string NazivDokumenta { get; set; }
        /// <summary>
        ///  datum
        /// </summary>
        public DateTime datum { get; set; }

        ///P pravno lice, F fizicko lice
        [StringLength(1)]
        public String vrstaPodnosiocaDokumenta { get; set; }
    }
}
