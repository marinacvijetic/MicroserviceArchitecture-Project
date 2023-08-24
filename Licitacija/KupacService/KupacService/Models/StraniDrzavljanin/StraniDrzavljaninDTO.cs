using KupacService.Entities.Enumeration;
using KupacService.Models.OvlascenoLice;

namespace KupacService.Models.StraniDrzavljanin
{
    /// <summary>
    /// DTO za ovlašćeno lice koje je strani državljanin.
    /// </summary>
    public class StraniDrzavljaninDTO : OvlascenoLiceDTO
    {
        /// <summary>
        /// Jedinstveni broj pasoša
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Država čiji je građanin ovlašćeno lice.
        /// </summary>
        public Drzava Drzava { get; set; }
    }
}
