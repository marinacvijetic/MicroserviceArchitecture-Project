using KupacService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Entities
{
    /// <summary>
    /// Tip kupca - fizičko lice
    /// </summary>
    public class FizickoLice : Kupac
    {
        /// <summary>
        /// Ime 
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Jedinstveni identifikacioni broj građanina
        /// </summary>
        public string JMBG { get; set; }

    }
}
