using KupacService.Entities.Enumeration;
using KupacService.Entities;
using System.Collections.Generic;
using System;
using KupacService.Models.OvlascenoLice;
using KupacService.Models.Prioritet;
using KupacService.Models.FizickoLice;

namespace KupacService.Models.Kupac
{
    /// <summary>
    /// DTO za potvrdu kupca
    /// </summary>
    public class KupacDTOConfirmation
    {
        /// <summary>
        /// Činjenice o kupcu na osnovu kojih on postaje prioritet.
        /// </summary>
        public ICollection<PrioritetDTO> Prioriteti { get; set; }

        /// <summary>
        /// Tip kupca (npr. Fizičko lice ili Pravno lice).
        /// </summary>
        public string TipKupca { get; set; }

        /// <summary>
        /// Površina zemljišta za koju kupac licitira.
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// Sve uplate koje je kupac izvršio.
        /// </summary>
        public ICollection<UplataDTO> Uplate { get; set; }

        /// <summary>
        /// Ovlašćena lica koja mogu da učestvuju u nadmetanju u ime kupca.
        /// </summary>
        public ICollection<OvlascenoLiceDTO> OvlascenaLica { get; set; }

        /// <summary>
        /// Informacija o tome da li postoji zabrana da se kupac nadmeće.
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Datum početka zabrane.
        /// </summary>
        public DateTime DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Dužina trajanja zabrane u godinama.
        /// </summary>
        public int DuzinaTrajanjaZabraneGodine { get; set; }

        /// <summary>
        /// Datum kada se zabrana ukida.
        /// </summary>
        public DateTime DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Javna nadmetanja na kojima se kupac nadmeće.
        /// </summary>
        public ICollection<JavnoNadmetanjeDTO> JavnaNadmetanja { get; set; }

        /// <summary>
        /// Adresa kupca.
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Kontakt telefon 1.
        /// </summary>
        public string BrojTelefona1 { get; set; }

        /// <summary>
        /// Kontakt telefon 2.
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email adresa kupca
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj tekućeg računa u banci.
        /// </summary>
        public string BrojRacuna { get; set; }
    }
}
