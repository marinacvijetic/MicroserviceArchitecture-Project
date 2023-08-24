using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Kupac koji je pravno lice
    /// </summary>
    public class PravnoLice : Kupac
    {
        /// <summary>
        /// Naziv
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj
        /// </summary>
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Kontakt osoba za pravno lice
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
        /// <summary>
        /// Navigaciono polje za strani ključ
        /// </summary>
        [ForeignKey("KontaktOsobaID")]
        public KontaktOsoba KontaktOsoba { get; set; }

        /// <summary>
        /// Faks
        /// </summary>
        public string Faks { get; set; }
    }
}
