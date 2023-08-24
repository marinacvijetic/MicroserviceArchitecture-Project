using System;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda Kontakt osobe. 
    /// </summary>
    public class KontaktOsobaConfirmation
    {
        /// <summary>
        /// ID kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Funkcija
        /// </summary>
        public string Funkcija { get; set; }

        /// <summary>
        /// Kontakt telefon
        /// </summary>
        public string Telefon { get; set; }
    }
}
