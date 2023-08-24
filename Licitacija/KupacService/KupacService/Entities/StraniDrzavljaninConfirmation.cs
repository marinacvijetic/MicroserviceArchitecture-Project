using KupacService.Entities.Enumeration;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda stranog državljanina
    /// </summary>
    public class StraniDrzavljaninConfirmation : OvlascenoLiceConfirmation
    {
        /// <summary>
        /// Broj pasoša
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Drzava 
        /// </summary>
        public Drzava Drzava { get; set; }
    }
}
