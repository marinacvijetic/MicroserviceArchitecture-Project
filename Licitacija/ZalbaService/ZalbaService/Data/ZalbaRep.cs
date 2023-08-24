using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Data.Context;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public class ZalbaRep : IZalbaRep
    {
        private readonly ZalbaDBContext _context;

        public ZalbaRep(ZalbaDBContext context)
        {
            _context = context;
        }
        public void CreateZalba(Zalba zalba)
        {
            if (zalba == null)
            {
                throw new ArgumentNullException(nameof(zalba));
            }

            _context.Zalbe.Add(zalba);
        }

        public void DeleteZalba(Guid zalbaId)
        {
            var zalbaItem = GetZalbaById(zalbaId);
            if (zalbaItem != null)
            {
                _context.Remove(zalbaItem);
            }
        }

        public IEnumerable<Zalba> GetAllZalbe()
        {
            return _context.Zalbe.ToList();
        }

        public Zalba GetZalbaById(Guid id)
        {
            return _context.Zalbe.FirstOrDefault(z => z.ZalbaID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateZalba(Zalba zalba)
        {
            //nije neophodna implementacija metode
        }
    }
}
