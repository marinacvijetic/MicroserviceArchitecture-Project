using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using KupacService.Entities.Enumeration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Ovlasceno lice repozitorijum 
    /// </summary>
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public OvlascenoLiceRepository(KupacDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Post metoda - definicija
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            if (ovlascenoLice == null)
            {
                throw new ArgumentNullException(nameof(ovlascenoLice));
            }

            _context.OvlascenaLica.Add(ovlascenoLice);
        }

        /// <summary>
        /// Delete metoda - definicija
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteOvlascenoLice(Guid ovlascenoLiceID)
        {
            var OvlascenoLice = _context.OvlascenaLica.Find(ovlascenoLiceID);
            if (OvlascenoLice == null)
            {
                throw new ArgumentException($"Ovlašćeno lice sa ID-jem {ovlascenoLiceID} nije pronađen.");
            }

            _context.OvlascenaLica.Remove(OvlascenoLice);
        }

        /// <summary>
        /// Get All - definicija
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OvlascenoLice> GetAllOvlascenaLica()
        {
            // Get all instances of the base class and filter out any that aren't also instances of the derived classes.
            var allOvlascenaLica = _context.Set<OvlascenoLice>().ToList();
            var srpskiDrzavljani = allOvlascenaLica.Where(k => k is SrpskiDrzavljanin).Cast<SrpskiDrzavljanin>().ToList();
            var straniDrzavljani = allOvlascenaLica.Where(k => k is StraniDrzavljanin).Cast<StraniDrzavljanin>().ToList();

            _context.SaveChanges();
            // Perform any additional processing or filtering as needed.

            // Combine the results into a single list and return it.
            return srpskiDrzavljani.Cast<OvlascenoLice>().Concat(straniDrzavljani.Cast<OvlascenoLice>());
        }

        /// <summary>
        /// Get By ID - definicija
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        /// <returns></returns>
        public OvlascenoLice GetOvlascenoLiceByID(Guid ovlascenoLiceID)
        {
            return _context.OvlascenaLica.FirstOrDefault(p => p.OvlascenoLiceID == ovlascenoLiceID);
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
        /// <param name="ovlascenoLice"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            if (ovlascenoLice == null)
            {
                throw new ArgumentNullException(nameof(ovlascenoLice));
            }

            _context.OvlascenaLica.Update(ovlascenoLice);
        }
    }
}
