using KupacService.Entities.Enumeration;

namespace KupacService.Entities
{
    /// <summary>
    /// Ovlašćeno lice koje je strani državljanin
    /// </summary>
    public class StraniDrzavljanin : OvlascenoLice
    {
        /// <summary>
        /// Broj Pasoša
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Država stranog državljanina
        /// </summary>
        public Drzava Drzava { get; set; }
    }
}
