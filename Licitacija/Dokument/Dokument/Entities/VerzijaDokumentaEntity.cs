using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokument.Entities
{
    /// <summary>
    /// Predstavlja verziju dokumenta
    /// </summary>
    public class VerzijaDokumentaEntity
    {
        /// <summary>
        /// Identifikaciona oznaka verzije dokumenta
        /// </summary>
        [Key]
        public Guid VerzijaID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka dokumenta
        /// </summary>
        [NotMapped]
        public int DokumentID { get; set; }
        //[ForeignKey("DokumentID")]

        /// <summary>
        /// Verzija dokumenta
        /// </summary>
        public string Verzija { get; set; }

        /// <summary>
        /// Revizija dokumenta
        /// </summary>
        public string Revizija { get; set; }

        /// <summary>
        /// Datum verzije
        /// </summary>
        public DateTime Datum { get; set; }
    }
}
