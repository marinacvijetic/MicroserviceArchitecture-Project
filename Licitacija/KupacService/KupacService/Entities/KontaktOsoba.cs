using System;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Entities
{
    /// <summary>
    /// Kontakt Osoba entitet
    /// </summary>
    public class KontaktOsoba
    {
        /// <summary>
        /// ID kontakt osobe
        /// </summary>
        [Key]
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
        /// Telefon
        /// </summary>
        public string Telefon { get; set; }
    }
}
