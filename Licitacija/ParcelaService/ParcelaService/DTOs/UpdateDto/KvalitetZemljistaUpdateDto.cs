using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model kvaliteta zemljista koji se koristi prilikom azuriranja podataka.
    /// </summary>
    public class KvalitetZemljistaUpdateDto
    {
        /// <summary>
        /// Id kvaliteta zemljista.
        /// </summary>
        public Guid KvalitetZemljistaId { get; set; }

        /// <summary>
        /// Oznaka kvaliteta zemljista.
        /// </summary>
        public string OznakaKvaliteta { get; set; }

        /// <summary>
        /// Opis kvaliteta zemljista.
        /// </summary>
        public string Opis { get; set; }
    }
}
