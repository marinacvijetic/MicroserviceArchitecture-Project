using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Dokument.Models.VerzijaDokumenta
{
    /// <summary>
    /// Predstavlja model verzije dokumenta
    /// </summary>
    public class VerzijaDokumentaDTO
    {
        /// <summary>
        /// Identifikaciona oznaka verzije dokumenta
        /// </summary>
        public Guid VerzijaID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka dokumenta
        /// </summary>
        public int DokumentID { get; set; }

        /// <summary>
        /// Verzija dokumenta
        /// </summary>
        public string Verzija { get; set; }

        /// <summary>
        /// Revizija dokumenta
        /// </summary>
        public string Revizija { get; set; }

        /// <summary>
        /// Datum verzije dokumenta
        /// </summary>
        public DateTime Datum { get; set; }
    }
}
