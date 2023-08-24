using KupacService.Models.OvlascenoLice;

namespace KupacService.Models.SrpskiDrzavljanin
{
    /// <summary>
    /// DTO za potvrdu ovlašćenog lica koje je srpski državljanin.
    /// </summary>
    public class SrpskiDrzavljaninDTOConfirmation : OvlascenoLiceDTOConfirmation
    {
        /// <summary>
        /// Jedinstveni matični broj građanina Srbije.
        /// </summary>
        public string JMBG { get; set; }
    }
}
