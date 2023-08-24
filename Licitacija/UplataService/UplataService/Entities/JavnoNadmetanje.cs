using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Entities
{
    /// <summary>
    /// Predstavlja realni entitet javnog nadmetanja.
    /// </summary>
    public class JavnoNadmetanje
    {
        /// <summary>
        /// Identifikaciona oznaka javnog nadmetanja.
        /// </summary>
        [Key]
        public Guid JavnoNadmetanjeID { get; set; }
    }
}
