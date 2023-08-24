using KupacService.Entities;
using System.Collections.Generic;
using System;

namespace KupacService.Data.Interfaces
{
    /// <summary>
    /// Kontakt osoba interfejs
    /// </summary>
    public interface IKontaktOsobaRepository
    {
        /// <summary>
        /// Get metoda
        /// </summary>
        /// <returns></returns>
        IEnumerable<KontaktOsoba> GetAllKontaktOsobe();

        /// <summary>
        /// Get By ID
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
        /// <returns></returns>
        KontaktOsoba GetKontaktOsobuByID(Guid kontaktOsobaID);

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="kontaktOsoba"></param>
        void CreateKontaktOsobu(KontaktOsoba kontaktOsoba);

        /// <summary>
        /// Put metoda
        /// </summary>
        /// <param name="kontaktOsoba"></param>
        void UpdateKontaktOsobu(KontaktOsoba kontaktOsoba);

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
        void DeleteKontaktOsobu(Guid kontaktOsobaID);

        /// <summary>
        /// Save metoda 
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
