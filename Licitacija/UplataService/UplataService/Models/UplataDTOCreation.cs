using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Models
{
    /// <summary>
    /// Predstvalja model uplate prilikom kreiranja tipa.
    /// </summary>
    public class UplataDTOCreation
    {

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        [Required(ErrorMessage = "Obavezan poziv na broj")]
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Iznos uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezan iznos")]
        public decimal Iznos { get; set; }

        /// <summary>
        /// Identifikaciona oznaka uplatioca.
        /// </summary>
        [Required(ErrorMessage = "Obavezan ID uplatioca")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezna svrha uplate")]
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Datum uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezan datum uplate")]
        public DateTime Datum { get; set; }

        /// <summary>
        /// Identifikaciona oznaka javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezan ID nadmetanja")]
        public Guid JavnoNadmetanjeID { get; set; }
    }
}
