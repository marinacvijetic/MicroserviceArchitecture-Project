using Dokument.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Dokument.Models.UgovorOZakupu
{
    /// <summary>
    /// Predstavlja model ugovora o zakupu
    /// </summary>
    public class UgovorOZakupuDTO
    {
        /// <summary>
        /// Identifikaciona oznaka ugovora o zakupu(primarni kljuc)
        /// </summary>
        public Guid UgovorOZakupuID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka jadnog nagmetanja (strani kljuc)
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Identifikaciona oznaka dokumenta (strani kljuc)
        /// </summary>

        public int DokumentID { get; set; }

        /// <summary>
        /// Tip garancije za ugovor o zakupu
        /// </summary>

        public TipGarancijeEnum TipGarancije { get; set; }

        /// <summary>
        /// Identifikaciona oznaka kupca (strani kljuc)
        /// </summary>
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
