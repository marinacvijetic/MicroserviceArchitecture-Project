using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KupacService.Entities
{
    /// <summary>
    /// Pravno lice potvrda
    /// </summary>
    public class PravnoLiceConfirmation : KupacConfirmation
    {
        /// <summary>
        /// Nayiv
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj
        /// </summary>
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Kontakt osoba
        /// </summary>
        public Guid KontaktOsobaID { get; set; }

        /// <summary>
        /// Faks
        /// </summary>
        public string Faks { get; set; }
    }
}
