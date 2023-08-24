using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;

namespace UplataService.Data
{
    public class UplataRep : IUplataRep
    {
        private readonly UplataDBContext _context;

        public UplataRep(UplataDBContext context)
        {
            _context = context;
        }
        public void CreateUplata(Uplata uplata)
        {
            if (uplata == null)
            {
                throw new ArgumentNullException(nameof(uplata));
            }

            _context.Uplate.Add(uplata);
        }

        public void DeleteUplata(Guid uplataId)
        {
            var uplataItem = GetUplataById(uplataId);
            if (uplataItem != null)
            {
                _context.Remove(uplataItem);
            }
        }

        public IEnumerable<Uplata> GetAllUplate(Guid? kupacId)
        {
            return _context.Uplate.ToList();
        }

        public Uplata GetUplataById(Guid id)
        {
            return _context.Uplate.FirstOrDefault(u => u.UplataID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUplata(Uplata zalba)
        {
           
        }
    }
}
