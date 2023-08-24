using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.CreateDto
{
    /// <summary>
    /// Predstavlja model dozvoljenog rada prilikom kreiranja tipa.
    /// </summary>
    public class DozvoljeniRadCreateDto
    {
        /// <summary>
        /// Opis dozvoljenog rada.
        /// </summary>
        public string Opis { get; set; }

        /// <summary>
        /// Id zasticene zone
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }
    }
}
