using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs
{
    /// <summary>
    /// Predstavlja model dela parcele.
    /// </summary>
    public class DeoParceleDto
    {
        /// <summary>
     /// Id dela parcele.
     /// </summary>
        public Guid DeoParceleId { get; set; }

        /// <summary>
        /// Id parcele.
        /// </summary>
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Redni broj dela parcele.
        /// </summary>
        public int RedniBrojDelaParcele { get; set; }

        /// <summary>
        /// Povrsina dela parcele.
        /// </summary>
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// Id kvaliteta zemljista.
        /// </summary>
        public Guid KvalitetZemljistaId { get; set; }
    }
}
