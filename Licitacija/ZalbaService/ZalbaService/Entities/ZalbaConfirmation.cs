using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Entities
{
    /// <summary>
    /// Predstavlja realni entitet žalbe za potvrdu.
    /// </summary>
    public class ZalbaConfirmation
    {
        /// <summary>
        /// Id žalbe.
        /// </summary>
        public Guid ZalbaID { get; set; }

        /// <summary>
        /// Tip žalbe.
        /// </summary>
        public TipZalbe TipZalbe { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe.
        /// </summary>
        public DateTime DatumPodnosenjaZalbe { get; set; }

        /// <summary>
        /// Id kupca.
        /// </summary>
        [NotMapped]
        public Guid KupacID { get; set; }

        /* public Kupac Kupac { get; set; } */

        /// <summary>
        /// Razlog žalbe.
        /// </summary>
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazloženje žalbe.
        /// </summary>
        public string Obrazlozenje { get; set; }

        /// <summary>
        /// Datum rešenja.
        /// </summary>
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Broj rešenja.
        /// </summary>
        public string BrojResenja { get; set; }

        /// <summary>
        /// Status žalbe.
        /// </summary>
        public StatusZalbe StatusZalbe { get; set; }

        /// <summary>
        /// Broj odluke.
        /// </summary>
        public string BrojOdluke { get; set; }

        /// <summary>
        ///Radnja na osnovu žalbe.
        /// </summary>
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
    }
}
