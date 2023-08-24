using Dokument.Entities;
using System;

namespace Dokument.Models.Dokument
{
    public class DokumentDTOUpdate
    {
        /// <summary>
        /// Identifikaciona oznaka dokumenta
        /// </summary>
        public int DokumentID { get; set; }

        /// <summary>
        /// Zavodni broj dokumenta
        /// </summary>
        public string ZavodniBroj { get; set; }

        /// <summary>
        /// Datum
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Datum donosenja dokumenta
        /// </summary>
        public DateTime DatumDonosenjaDokumenta { get; set; }

        /// <summary>
        /// Sablon dokumenta
        /// </summary>
        public string Sablon { get; set; }

        /// <summary>
        /// Status dokumenta
        /// </summary>
        public StatusDokumentaEnum StatusDokumenta { get; set; }

        /// <summary>
        /// Identifikaciona oznaka verzije dokumenta
        /// </summary>
        public int VerzijaDokumentaID { get; set; }
    }
}
