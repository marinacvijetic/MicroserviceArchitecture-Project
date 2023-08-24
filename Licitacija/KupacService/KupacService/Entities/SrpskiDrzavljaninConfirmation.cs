namespace KupacService.Entities
{
    /// <summary>
    /// Povtrda za ovlašćeno lice koje je srpski državljanin
    /// </summary>
    public class SrpskiDrzavljaninConfirmation : OvlascenoLiceConfirmation
    {
        /// <summary>
        /// JMBG ovlašćenog lica
        /// </summary>
        public string JMBG { get; set; }
    }
}
