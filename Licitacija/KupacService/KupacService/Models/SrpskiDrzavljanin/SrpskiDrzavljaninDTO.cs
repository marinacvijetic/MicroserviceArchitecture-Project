using KupacService.Models.OvlascenoLice;

namespace KupacService.Models.SrpskiDrzavljanin
{
    /// <summary>
    /// DTO za srpskog državljanina.
    /// </summary>
    public class SrpskiDrzavljaninDTO : OvlascenoLiceDTO
    {
        /// <summary>
        /// Jedinstveni matični broj građanina Srbije.
        /// </summary>
        public string JMBG { get; set; }
    }
}
