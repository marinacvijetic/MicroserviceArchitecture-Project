using KupacService.Entities;
using System.Collections.Generic;
using System;

namespace KupacService.Data.Interfaces
{
    /// <summary>
    /// Broj Table interfejs
    /// </summary>
    public interface IBrojTableRepository
    {
        /// <summary>
        /// Get metoda
        /// </summary>
        /// <returns></returns>
        IEnumerable<BrojTable> GetAllBrojeviTabla();

        /// <summary>
        /// Get By ID
        /// </summary>
        /// <param name="brojTableID"></param>
        /// <returns></returns>
        BrojTable GetBrojTableByID(Guid brojTableID);

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="brojTable"></param>
        void CreateBrojTable(BrojTable brojTable);

        /// <summary>
        /// Put metoda
        /// </summary>
        /// <param name="brojTable"></param>
        void UpdateBrojTable(BrojTable brojTable);

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="brojTableID"></param>
        void DeleteBrojTable(Guid brojTableID);

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
