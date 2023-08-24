using KupacService.Entities;
using System;
using System.Collections.Generic;

namespace KupacService.Data.Interfaces
{
    /// <summary>
    /// Kupac interfejs
    /// </summary>
    public interface IKupacRepository
    {
        /// <summary>
        /// Get all metoda
        /// </summary>
        /// <returns></returns>
        IEnumerable<Kupac> GetAllKupci();

        /// <summary>
        /// Get By ID
        /// </summary>
        /// <param name="kupacID"></param>
        /// <returns></returns>
        Kupac GetKupacByID(Guid kupacID);

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="kupac"></param>
        void CreateKupac(Kupac kupac);

        /// <summary>
        /// Put metoda
        /// </summary>
        /// <param name="kupac"></param>
        void UpdateKupac(Kupac kupac);

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="kupacID"></param>
        void DeleteKupac(Guid kupacID);

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
