using System.ComponentModel.DataAnnotations.Schema;
using System;
using KupacService.Models.Kupac;

namespace KupacService.Models.PravnoLice
{
    /// <summary>
    /// DTO za kupca koji je pravno lice
    /// </summary>
    public class PravnoLiceDTO : KupacDTO
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// PIB, registarski broj pravnog lica
        /// </summary>
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Kontakt osoba pravnog lica
        /// </summary>
        public Guid KontaktOsobaID { get; set; }

        /// <summary>
        /// Faks informacije
        /// </summary>
        public string Faks { get; set; }
    }
}
