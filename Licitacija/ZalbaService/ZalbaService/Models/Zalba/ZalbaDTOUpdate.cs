using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Models.Zalba
{
    /// <summary>
    /// Predstvalja model žalbe prilikom ažuriranja tipa.
    /// </summary>
    public class ZalbaDTOUpdate
    {
        /// <summary>
        /// Identifikaciona oznaka žalbe.
        /// </summary>
        public Guid ZalbaId { get; set; }
        [Required]

        /// <summary>
        /// Tip žalbe.
        /// </summary>
        public TipZalbe TipZalbe { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe.
        /// </summary>
        [Required]
        public DateTime DatumPodnosenjaZalbe { get; set; }

        /// <summary>
        /// Identifikaciona oznaka kupca koji je podneo žalbu.
        /// </summary>
        [Required]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Razlog žalbe.
        /// </summary>
        [Required]
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazloženje žalbe.
        /// </summary>
        [Required]
        public string Obrazlozenje { get; set; }

        /// <summary>
        /// Datum repenja.
        /// </summary>
        [Required]
        public DateTime DatumResenja { get; set; }


        /// <summary>
        /// Broj rešenja.
        /// </summary>
        [Required]
        public string BrojResenja { get; set; }

        /// <summary>
        /// Status žalbe.
        /// </summary>
        [Required]
        public StatusZalbe StatusZalbe { get; set; }

        /// <summary>
        /// Broj odluke.
        /// </summary>
        [Required]
        public string BrojOdluke { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe.
        /// </summary>
        [Required]
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
    }
}
