using Dokument.Models;
using Dokument.Models.Dokument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokument.Entities
{
    /// <summary>
    /// Predstavlja ugovor o zakupu
    /// </summary>
    public class UgovorOZakupuEntity
    {
        /// <summary>
        /// Identifikaciona oznaka ugovora o zakupu(primarni kljuc)
        /// </summary>
        [Key]
        public Guid UgovorOZakupuID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka jadnog nagmetanja (strani kljuc)
        /// </summary>
        [NotMapped]
        //[ForeignKey("JavnoNadmetanjeID")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka dokumenta (strani kljuc)
        /// </summary>
        [NotMapped]
        // [ForeignKey("DokumentID")]
        public int DokumentID { get; set; }


        /// <summary>
        /// Tip garancije za ugovor o zakupu
        /// </summary>
        public TipGarancijeEnum TipGarancije { get; set; }

        /// <summary>
        /// Identifikaciona oznaka kupca (strani kljuc)
        /// </summary>
        [NotMapped]
        // [ForeignKey("KupacID")]
        public Guid KupacID { get; set; }


        /// <summary>
        /// Rok dospeca
        /// </summary>
        public int RokDospeca { get; set; }

        /// <summary>
        /// Zavodni broj ugovora o zakupu
        /// </summary>
        public string ZavodniBroj { get; set; }

        /// <summary>
        /// Datum zavodjenja ugovora o zakupu
        /// </summary>
        public DateTime DatumZavodjenja { get; set; }

        /// <summary>
        /// Identifikaciona oznaka ministra (strani kljuc)
        /// </summary>
        [NotMapped]
        // [ForeignKey("LicnostID")]
        public Guid LicnostID { get; set; }

        /// <summary>
        /// Rok za vracanje
        /// </summary>
        public DateTime RokZaVracanje { get; set; }

        /// <summary>
        /// Mesto potpisivanja ugovora
        /// </summary>
        public string MestoPotpisivanja { get; set; }

        /// <summary>
        /// Datum potpisivanja ugovora
        /// </summary>
        public DateTime DatumPotpisivanja { get; set; }





    }
}
