using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    /// <summary>
    /// Predstvalja model kupca.
    /// </summary>
    public class KupacDTO
    {
        /// <summary>
        /// Identifikaciona oznaka kupca koji je podneo žalbu.
        /// </summary>
        public Guid KupacID { get; set; }
    }
}
