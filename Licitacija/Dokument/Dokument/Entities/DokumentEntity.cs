using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokument.Entities
{
    /// <summary>
    /// Predstavlja dokument
    /// </summary>
    public class DokumentEntity
    {
        /// <summary>
        /// Identifikaciona oznaka dokumenta
        /// </summary>
        [Key]
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
        /// Identifikaciona oznaka verzije dokumenta
        /// </summary>
        [NotMapped]
        public int VerzijaDokumentaID { get; set; }
        //[ForeignKey("VerzijaDokumentaID")]

        /// <summary>
        /// Status dokumenta
        /// </summary>
        public StatusDokumentaEnum StatusDokumenta { get; set; }

    

    }


}
