using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// klasa DokumentUpdateDTO
    /// </summary>
    public class DokumentUpdateDTO
    {
        /// <summary>
        /// Identifikator dokumenta
        /// </summary>
        public Guid dokumentId { get; set; }
        /// <summary>
        /// Identifikator lictacije
        /// </summary>
        public Guid LicitacijaID { get; set; }
        /// <summary>
        /// naziv dokumenta
        /// </summary>
        public string NazivDokumenta { get; set; }
        ///P pravno lice, F fizicko lice
        public string vrstaPodnosiocaDokumenta { get; set; }
        /// <summary>
        ///  datum
        /// </summary>
        public DateTime datum { get; set; }
    }
}
