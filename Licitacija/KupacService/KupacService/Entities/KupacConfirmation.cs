using KupacService.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using KupacService.Entities.Enumeration;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda kupca
    /// </summary>
    public class KupacConfirmation
    {
        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacID { get; set; }

        /// <summary>
        /// Prioriteti 
        /// </summary>
        public ICollection<Prioritet> Prioriteti { get; set; }

        /// <summary>
        /// Tip kupca (Fizičko ili pravno lice)
        /// </summary>
        public string TipKupca { get; set; }

        /// <summary>
        /// Ostvarena površina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// Uplate kupca
        /// </summary>
        public ICollection<UplataDTO> Uplate { get; set; }

        /// <summary>
        /// Ovlašćena lica za kupca
        /// </summary>
        public ICollection<OvlascenoLice> OvlascenaLica { get; set; }

        /// <summary>
        /// Da li kupac ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Datum početka zabrane
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Godine trajanja zabrane
        /// </summary>
        public int? DuzinaTrajanjaZabraneGodine { get; set; }

        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Javna nadmetanja na koja je kupac prijavljen
        /// </summary>
        public virtual ICollection<JavnoNadmetanjeDTO> JavnaNadmetanja { get; set; }

        /// <summary>
        /// Adresa kupca
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Kontakt telefon
        /// </summary>
        public string BrojTelefona1 { get; set; }

        /// <summary>
        /// Kontakt telefon
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj Racuna
        /// </summary>
        public string BrojRacuna { get; set; }

    }
}
