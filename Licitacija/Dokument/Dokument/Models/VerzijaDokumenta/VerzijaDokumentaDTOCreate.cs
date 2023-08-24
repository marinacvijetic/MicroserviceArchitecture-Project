using System;

namespace Dokument.Models.VerzijaDokumenta
{
    /// <summary>
    /// Predstavlja model verzije dokumenta prilikom kreiranja
    /// </summary>
    public class VerzijaDokumentaDTOCreate
    {
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
