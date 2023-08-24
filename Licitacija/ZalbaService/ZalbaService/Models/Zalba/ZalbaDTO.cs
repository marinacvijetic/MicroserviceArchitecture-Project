using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Models.Zalba
{
        /// <summary>
        /// Predstavlja model žalbe.
        /// </summary>
    public class ZalbaDTO
    {
        /// <summary>
        /// Identifikaciona oznaka žalbe.
        /// </summary>
        public Guid ZalbaID { get; set; }

        /// <summary>
        /// Tip žalbe.
        /// </summary>
        public TipZalbe TipZalbe { get; set; }

        /// <summary>
        /// Datum žalbe.
        /// </summary>
        public DateTime DatumPodnosenjaZalbe { get; set; }

        /// <summary>
        /// Identifikaciona oznaka kupca koji je podneo žalbu.
        /// </summary>
        public Guid KupacID { get; set; }

        /// <summary>
        /// Razlog podnošenja žalbe.
        /// </summary>
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazlozenje podnosenja žalbe.
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
        /// Radnja na osnovu žalbe.
        /// </summary>
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
    }
}
