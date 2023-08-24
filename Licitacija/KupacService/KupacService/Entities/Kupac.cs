using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using KupacService.Models;
using KupacService.Entities.Enumeration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace KupacService.Entities
{
    /// <summary>
    /// Kupac entitet
    /// </summary>
    public class Kupac
    {
        /// <summary>
        /// Kupac ID
        /// </summary>
        [Key]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Lista prioriteta.
        /// </summary>
        public ICollection<Prioritet> Prioriteti { get; set; }

        /// <summary>
        /// Tip Kupca
        /// </summary>
        public string TipKupca { get; set; }

        /// <summary>
        /// Ostvarena povrsina.
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// Lista uplata kupca. 
        /// </summary>
        [NotMapped]
        public ICollection<UplataDTO> Uplate { get; set; }

        /// <summary>
        /// Lista ovlašćenih lica za kupca.
        /// </summary>
        public ICollection<OvlascenoLice> OvlascenaLica { get; set; }

        /// <summary>
        /// Da li kupac ima zabranu za nadmetanje.
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Datum početka zabrane.
        /// </summary>
        public DateTime DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Godine trajanja zabrane.
        /// </summary>
        public int DuzinaTrajanjaZabraneGodine { get; set; }

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        public DateTime DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Lista javnih nadmetanja na koje se kupac prijavio.
        /// </summary>
        [NotMapped]
        public ICollection<JavnoNadmetanjeDTO> JavnaNadmetanja { get; set; }

        /// <summary>
        /// Adresa Kupca
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Broj telenofa
        /// </summary>
        public string BrojTelefona1 { get; set; }

        /// <summary>
        /// Broj telefona
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa
        /// </summary>
        public string BrojRacuna { get; set; }

    }
}
