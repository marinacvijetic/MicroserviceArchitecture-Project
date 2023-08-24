using System;

namespace KupacService.Models.KontaktOsoba
{
    /// <summary>
    /// DTO za potvrdu kontakt osobe.
    /// </summary>
    public class KontaktOsobaDTOConfirmation
    {
        /// <summary>
        /// Ime osobe.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime osobe.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Funkcija koju osoba vrši.
        /// </summary>
        public string Funkcija { get; set; }

        /// <summary>
        /// Kontakt telefon osobe.
        /// </summary>
        public string Telefon { get; set; }
    }
}
