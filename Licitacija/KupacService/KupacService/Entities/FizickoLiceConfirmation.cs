using System;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda fizičkog lica
    /// </summary>
    public class FizickoLiceConfirmation : KupacConfirmation
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
        /// JMBG
        /// </summary>
        public string JMBG { get; set; }
    }
}
