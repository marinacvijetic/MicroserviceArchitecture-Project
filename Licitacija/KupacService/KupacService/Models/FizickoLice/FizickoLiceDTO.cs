using KupacService.Models.Kupac;

namespace KupacService.Models.FizickoLice
{
    /// <summary>
    /// DTO za kupca koji je fizičko lice
    /// </summary>
    public class FizickoLiceDTO : KupacDTO
    {
        /// <summary>
        /// Ime fizičkog lica.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime fizičkog lica.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Jedinstveni matični broj građanina.
        /// </summary>
        public string JMBG { get; set; }
    }
}
