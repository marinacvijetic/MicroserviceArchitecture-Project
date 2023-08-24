using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities.Enumeration;

namespace ZalbaService.Models.Zalba
{
    /// <summary>
    /// Predstvalja model žalbe koji služi za potvrdu.
    /// </summary>
    public class ZalbaDTOConfirmation
    {
        /// <summary>
        /// Tip žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan tip zalbe")]
        public TipZalbe TipZalbe { get; set; }

        /// <summary>
        /// Datum žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum podnosenja zalbe")]
        public DateTime DatumPodnosenjaZalbe { get; set; }

        /// <summary>
        /// Identifikaciona oznaka kupca koji je podneo žalbu.
        /// </summary>
        [Required(ErrorMessage = "Obavezan ID podnosioca zalbe")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Razlog podnosenja žalbe.
        /// </summary> 
        [Required(ErrorMessage = "Obavezan razlog zalbe")]
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazloženje podnošenja žalbe.
        /// </summary>
        public string Obrazlozenje { get; set; }

        /// <summary>
        /// Datum rešenja.
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum resenja")]
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Broj rešenja.
        /// </summary> 
        [Required(ErrorMessage = "Obavezan broj resenja")]
        public string BrojResenja { get; set; }

        /// <summary>
        /// Status žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan status zalbe")]
        public StatusZalbe StatusZalbe { get; set; }

        /// <summary>
        /// Broj odluke.
        /// </summary>
        [Required(ErrorMessage = "Obavezan broj odluke")]
        public string BrojOdluke { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe.
        /// </summary>
        [Required(ErrorMessage = "Obavezan odabir radnje na osnovu zalbe")]
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
    }
}
