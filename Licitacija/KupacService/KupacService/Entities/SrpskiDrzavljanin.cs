namespace KupacService.Entities
{
    /// <summary>
    /// Ovlašćeno lice koje je srpski državljanin
    /// </summary>
    public class SrpskiDrzavljanin : OvlascenoLice
    {
        /// <summary>
        /// JMBG ovlašćenog lica
        /// </summary>
        public string JMBG { get; set; }
    }
}
