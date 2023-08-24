using Licitacija1.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Entities
{
    public class DokumentModel
    {
        [Key]
        /// <summary>
        /// Identifikator dokumenta
        /// </summary>
        public Guid dokumentID { get; set; }

        [Required]
        [ForeignKey("licitacijaID")]
        /// <summary>
        /// Identifikator licitacije
        /// </summary>
        public Guid licitacijaID { get; set; }

        /// <summary>
        /// Datum podnosenja dokumenta
        /// </summary>
        public DateTime datum { get; set; }

        /// <summary>
        /// Nziv Dokumenta
        /// </summary>
        public string NazivDokumenta { get; set; }


        /// <summary>
        /// Indikator vrste podnosioca dokumenta
        ///P pravno lice, F fizicko lice
        /// </summary>
        [Required]
        [StringLength(1)]
        public String vrstaPodnosiocaDokumenta { get; set; }


       

    }
}
