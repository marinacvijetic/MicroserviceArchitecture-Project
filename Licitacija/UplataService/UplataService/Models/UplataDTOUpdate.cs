using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Models
{
    /// <summary>
    /// Predstvalja model uplate prilikom ažuriranja tipa.
    /// </summary>
    public class UplataDTOUpdate
    {
        [Required]
        public Guid UplataId { get; set; }

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        [Required]
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Iznos uplate.
        /// </summary>
        [Required]
        public decimal Iznos { get; set; }

        /// <summary>
        /// Identifikaciona oznaka uplatioca.
        /// </summary>
        [Required]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        [Required]
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Datum uplate.
        /// </summary>
        [Required]
        public DateTime Datum { get; set; }

        /// <summary>
        /// Identifikaciona oznaka javnog nadmetanja.
        /// </summary>
        [Required]
        public Guid JavnoNadmetanjeID { get; set; }
    }
}

