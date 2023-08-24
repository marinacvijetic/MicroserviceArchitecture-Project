using KupacService.Entities;
using KupacService.Models.Kupac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Models
{
    /// <summary>
    /// Javno nadmetanje DTO
    /// </summary>
    public class JavnoNadmetanjeDTO
    {
        /// <summary>
        /// ID Javnog nadmetanja.
        /// </summary>
        public Guid? JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Lista kupaca na javnom nadmetanju
        /// </summary>
        [NotMapped]
        public ICollection<Entities.Kupac> Kupci { get; set; }

    }
}
