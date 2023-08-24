using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Entities
{
    /// <summary>
    /// Predstavlja realni entitet kupca.
    /// </summary>
    public class Kupac
    {
        /// <summary>
        /// Identifikaciona oznaka kupca.
        /// </summary>
        [Key]
        public Guid KupacID { get; set; }

    }
}
