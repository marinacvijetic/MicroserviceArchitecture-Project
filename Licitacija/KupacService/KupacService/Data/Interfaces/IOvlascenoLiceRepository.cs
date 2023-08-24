using KupacService.Entities;
using System;
using System.Collections.Generic;

namespace KupacService.Data.Interfaces
{
    /// <summary>
    /// Ovlasceno lice interfejs
    /// </summary>
    public interface IOvlascenoLiceRepository
    {
        /// <summary>
        /// Get all metoda
        /// </summary>
        /// <returns></returns>
        IEnumerable<OvlascenoLice> GetAllOvlascenaLica();

        /// <summary>
        /// Get By ID metoda
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        /// <returns></returns>
        OvlascenoLice GetOvlascenoLiceByID(Guid ovlascenoLiceID);

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        void CreateOvlascenoLice(OvlascenoLice ovlascenoLice);

        /// <summary>
        /// Put metoda
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        void UpdateOvlascenoLice(OvlascenoLice ovlascenoLice);

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        void DeleteOvlascenoLice(Guid ovlascenoLiceID);

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
