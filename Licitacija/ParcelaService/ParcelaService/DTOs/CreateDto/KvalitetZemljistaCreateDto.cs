using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.CreateDto
{

    /// <summary>
    /// Predstavlja model kvaliteta zemljista prilikom kreiranja tipa.
    /// </summary>
    public class KvalitetZemljistaCreateDto
    {
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
