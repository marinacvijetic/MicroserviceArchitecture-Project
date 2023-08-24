using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Models
{
    /// <summary>
    /// Predstvalja model kupca.
    /// </summary>
    public class KupacDTO
    {
        /// <summary>
        /// Identifikaciona oznaka kupca koji je izvršio uplatu.
        /// </summary>
        public Guid KupacID { get; set; }
    }
}
