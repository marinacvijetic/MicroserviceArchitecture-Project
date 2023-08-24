using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs
{
    public class DozvoljeniRadDto
    {
        /// <summary>
        /// Id za dozvoljeni rad
        /// </summary>
        public Guid DozvoljeniRadId { get; set; }

        /// <summary>
        /// Opis dozvoljenog rada
        /// </summary>
        public string Opis { get; set; }


        /// <summary>
        /// Id zasticene zone - strani kljuc
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }
    }
}
