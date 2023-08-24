using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Entities
{
    public class Uplata
    {
        [Key]
        /// <summary>
        /// Identifikaciona oznaka uplate.
        /// </summary>
        public Guid UplataID { get; set; }

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Iznos uplate.
        /// </summary>
        public decimal Iznos { get; set; }

        /// <summary>
        /// Kupac koji je izvrsio uplatu, uplatilac.
        /// </summary>
        [NotMapped]
        public Guid KupacID { get; set; }
        //[ForeignKey("KupacID")]
        // public Kupac Kupac { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Datum uplate.
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Javno nadmetanje za koje je izvrsena uplata.
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }
        //[ForeignKey("JavnoNadmetanjeID")]
        //public JavnoNadmetanje JavnoNadmetanje { get; set; }



    }
}
