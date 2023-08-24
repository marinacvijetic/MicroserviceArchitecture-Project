using KupacService.Entities;
using System.Collections.Generic;
using System;

namespace KupacService.Data.Interfaces
{
    /// <summary>
    /// Interfejs prioritet
    /// </summary>
    public interface IPrioritetRepository
    {
        /// <summary>
        /// Get all metoda 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Prioritet> GetAllPrioriteti();

        /// <summary>
        /// Get By ID 
        /// </summary>
        /// <param name="prioritetID"></param>
        /// <returns></returns>
        Prioritet GetPrioritetByID(int prioritetID);

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="prioritet"></param>
        void CreatePrioritet(Prioritet prioritet);

        /// <summary>
        /// Put metoda
        /// </summary>
        /// <param name="prioritet"></param>
        void UpdatePrioritet(Prioritet prioritet);

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="prioritetID"></param>
        void DeletePrioritet(int prioritetID);

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
