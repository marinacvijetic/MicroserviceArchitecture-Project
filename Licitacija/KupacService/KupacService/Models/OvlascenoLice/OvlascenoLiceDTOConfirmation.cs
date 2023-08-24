using KupacService.Entities.Enumeration;
using KupacService.Models.BrojTable;
using KupacService.Models.Kupac;
using KupacService.Models.SrpskiDrzavljanin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Models.OvlascenoLice
{
    /// <summary>
    /// DTO za potvrdu ovlašćenog lica
    /// </summary>
    public class OvlascenoLiceDTOConfirmation
    {
        /// <summary>
        /// Tip ovlašćenog lica (Srpski, ili strani državljanin)
        /// </summary>
        public string TipOvlascenogLica { get; set; }

        /// <summary>
        /// Ime ovlašćenog lica.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime ovlašćenog lica.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Adresa ovlašćenog lica.
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Kupci u čije ime ovlašćeno lice učestvuje na nadmetanjima.
        /// </summary>
        public ICollection<KupacDTO> Kupci { get; set; }

        /// <summary>
        /// Brojevi tabla javnih nadmetanja na kojima ovlašćeno lice učestvuje.
        /// </summary>
        public ICollection<BrojTableDTO> BrojeviTabla { get; set; }
    }
}
