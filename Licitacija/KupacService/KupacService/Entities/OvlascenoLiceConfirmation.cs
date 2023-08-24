using KupacService.Entities.Enumeration;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda za ovlašćeno lice
    /// </summary>
    public class OvlascenoLiceConfirmation
    {
        /// <summary>
        /// ID ovlašćenog lica
        /// </summary>
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// Tip ovlašćenog lica (Srpski, ili strani državljanin)
        /// </summary>
        public string TipOvlascenogLica { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Adresa 
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Lista kupaca za koje je lice ovlašćeno
        /// </summary>
        public ICollection<Kupac> Kupci { get; set; }

        /// <summary>
        /// Brojevi tabla nadmetanja
        /// </summary>
        public ICollection<BrojTable> BrojeviTabla { get; set; }

    }
}
