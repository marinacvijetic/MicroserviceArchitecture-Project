using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Models.Zalba
{
    /// <summary>
    /// Predstvalja model žalbe prilikom kreiranja tipa.
    /// </summary>
    public class ZalbaDTOCreation
    {
        /// <summary>
        /// Identifikaciona oznaka žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan tip žalbe")]
        public TipZalbe TipZalbe { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum podnošenja žalbe")]
        public DateTime DatumPodnosenjaZalbe { get; set; }

        /// <summary>
        /// Identifikaciona oznaka podnosioca žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan ID podnosioca žalbe")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Razlog žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan razlog žalbe")]
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazloženje žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezno obrazloženje žalbe")]
        public string Obrazlozenje { get; set; }

        /// <summary>
        /// Datum rešenja.
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum rešenja")]
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Broj rešenja.
        /// </summary>
        [Required(ErrorMessage = "Obavezan broj rešenja")]
        public string BrojResenja { get; set; }

        /// <summary>
        /// Status žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan status žalbe")]
        public StatusZalbe StatusZalbe { get; set; }

        /// <summary>
        /// Broj odluke.
        /// </summary>
        [Required(ErrorMessage = "Obavezan broj odluke")]
        public string BrojOdluke { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan odabir radnje na osnovu žalbe")]
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
    }
}
