using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Korisnici.Entities
{
    /// <summary>
    /// Predstavlja korisnika
    /// </summary>
    public class KorisnikEntity
    {
        /// <summary>
        /// Primarni kljuc korisnika(identifikaciono obelezje)
        /// </summary>
        [Key]
        public int KorisnikID { get; set; }

        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string KorisnickoIme { get; set; }

        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string Lozinka { get; set; }

        /// <summary>
        /// Tip kojem korisnik moze pripadati
        /// </summary>
        public TipKorisnikaEnum TipKorisnika { get; set; }
    }
}
