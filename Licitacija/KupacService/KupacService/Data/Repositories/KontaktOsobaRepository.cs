using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Kontakt osoba repozitorijum
    /// </summary>
    public class KontaktOsobaRepository : IKontaktOsobaRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public KontaktOsobaRepository(KupacDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Post metoda - definicija
        /// </summary>
        /// <param name="kontaktOsoba"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateKontaktOsobu(KontaktOsoba kontaktOsoba)
        {
            if(kontaktOsoba == null)
            {
                throw new ArgumentNullException(nameof(kontaktOsoba));
            }

            _context.KontaktOsobe.Add(kontaktOsoba);
        }

        /// <summary>
        /// Delete metoda - definicija
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteKontaktOsobu(Guid kontaktOsobaID)
        {
            var KontaktOsoba = _context.KontaktOsobe.Find(kontaktOsobaID);
            if(KontaktOsoba == null)
            {
                throw new ArgumentException($"Kontakt osoba sa ID-jem {kontaktOsobaID} nije pronađena.");
            }

            _context.KontaktOsobe.Remove(KontaktOsoba);
        }
        /// <summary>
        /// Get all metoda - definicija
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KontaktOsoba> GetAllKontaktOsobe()
        {
            return _context.KontaktOsobe.ToList();
        }

        /// <summary>
        /// Get By ID - definicija
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
        /// <returns></returns>
        public KontaktOsoba GetKontaktOsobuByID(Guid kontaktOsobaID)
        {
            return _context.KontaktOsobe.FirstOrDefault(p => p.KontaktOsobaID == kontaktOsobaID);
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
        /// Update kontakt osoba
        /// </summary>
        /// <param name="kontaktOsoba"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateKontaktOsobu(KontaktOsoba kontaktOsoba)
        {
            if(kontaktOsoba == null)
            {
                throw new ArgumentNullException(nameof(kontaktOsoba));

            }

            _context.KontaktOsobe.Update(kontaktOsoba);
        }
    }
}
