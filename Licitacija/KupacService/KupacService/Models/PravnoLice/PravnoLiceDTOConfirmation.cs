using KupacService.Models.Kupac;
using System;

namespace KupacService.Models.PravnoLice
{
    /// <summary>
    /// DTO za potvrdu kupca koji je pravno lice
    /// </summary>
    public class PravnoLiceDTOConfirmation : KupacDTOConfirmation
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
