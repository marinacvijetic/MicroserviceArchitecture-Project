using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Prioritet repozitorijum
    /// </summary>
    public class PrioritetRepository : IPrioritetRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Prioritet konstruktor
        /// </summary>
        /// <param name="context"></param>
        public PrioritetRepository(KupacDBContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Post metoda
        /// </summary>
        /// <param name="prioritet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreatePrioritet(Prioritet prioritet)
        {
            if(prioritet == null)
            {
                throw new ArgumentNullException(nameof(prioritet));
            }

            _context.Prioriteti.Add(prioritet);
        }

        /// <summary>
        /// Delete metoda
        /// </summary>
        /// <param name="prioritetID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeletePrioritet(int prioritetID)
        {
            var Prioritet = _context.Prioriteti.Find(prioritetID);
            if(Prioritet == null)
            {
                throw new ArgumentException($"Prioritet sa ID-jem {prioritetID} nije pronađen.");
            }

            _context.Prioriteti.Remove(Prioritet);
        }

        /// <summary>
        /// Get All - definicija
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Prioritet> GetAllPrioriteti()
        {
            return _context.Prioriteti.ToList();
        }

        /// <summary>
        /// Get By ID 
        /// </summary>
        /// <param name="prioritetID"></param>
        /// <returns></returns>
        public Prioritet GetPrioritetByID(int prioritetID)
        {
            return _context.Prioriteti.FirstOrDefault(p => p.PrioritetID == prioritetID);
        }

        /// <summary>
        /// Save metoda 
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Put metoda - definicija 
        /// </summary>
        /// <param name="prioritet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdatePrioritet(Prioritet prioritet)
        {
            if (prioritet == null)
            {
                throw new ArgumentNullException(nameof(prioritet));
            }

            _context.Prioriteti.Update(prioritet);
        }
    }
}
