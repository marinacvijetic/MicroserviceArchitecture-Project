using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Broj table repozitorijum
    /// </summary>
    public class BrojTableRepository : IBrojTableRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public BrojTableRepository(KupacDBContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Definicija Post metode
        /// </summary>
        /// <param name="brojTable"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateBrojTable(BrojTable brojTable)
        {
            if (brojTable == null)
            {
                throw new ArgumentNullException(nameof(brojTable));
            }

            _context.BrojeviTabla.Add(brojTable);
        }

        /// <summary>
        /// Definicija delete metode
        /// </summary>
        /// <param name="brojTableID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteBrojTable(Guid brojTableID)
        {
            var BrojTable = _context.BrojeviTabla.Find(brojTableID);
            if (BrojTable == null)
            {
                throw new ArgumentException($"Broj table nije pronađen.");
            }

            _context.BrojeviTabla.Remove(BrojTable);
        }

        /// <summary>
        /// Get all definicija metode
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BrojTable> GetAllBrojeviTabla()
        {
            return _context.BrojeviTabla.ToList();
        }

        /// <summary>
        /// Definicija GetByID metode
        /// </summary>
        /// <param name="brojTableID"></param>
        /// <returns></returns>
        public BrojTable GetBrojTableByID(Guid brojTableID)
        {
            return _context.BrojeviTabla.FirstOrDefault(p => p.BrojTableID ==brojTableID);
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
        /// Definicija Put metode
        /// </summary>
        /// <param name="brojTable"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateBrojTable(BrojTable brojTable)
        {
            if (brojTable == null)
            {
                throw new ArgumentNullException(nameof(brojTable));
            }

            _context.BrojeviTabla.Update(brojTable);
        }
    }
}
