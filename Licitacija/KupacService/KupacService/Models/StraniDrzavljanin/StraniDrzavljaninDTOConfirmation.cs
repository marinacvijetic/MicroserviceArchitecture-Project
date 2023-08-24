using KupacService.Entities.Enumeration;
using KupacService.Models.OvlascenoLice;

namespace KupacService.Models.StraniDrzavljanin
{
    /// <summary>
    /// DTO za potvrdu ovlašćenog lica koje je strani državljanin.
    /// </summary>
    public class StraniDrzavljaninDTOConfirmation : OvlascenoLiceDTOConfirmation
    {
        /// <summary>
        /// Jedinstveni broj pasoša
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Država čiji je građanin ovlašćeno lice.
        /// </summary>
        public Drzava Drzava{ get; set; }
    }
}
