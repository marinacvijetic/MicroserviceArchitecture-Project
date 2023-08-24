using System;

namespace Dokument.Models.VerzijaDokumenta
{
    /// <summary>
    /// Predstavlja model verzije dokumenta prilikom izmene
    /// </summary>
    public class VerzijaDokumentaDTOUpdate
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
