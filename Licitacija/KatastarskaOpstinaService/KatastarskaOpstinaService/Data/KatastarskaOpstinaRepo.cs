using AutoMapper;
using KatastarskaOpstinaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatastarskaOpstinaService.Data
{
    public class KatastarskaOpstinaRepo : IKatastarskaOpstinaRepo
    {
        private readonly KatastarskaOpstinaDbContext _context;

        public KatastarskaOpstinaRepo(KatastarskaOpstinaDbContext context)
        {
            _context = context;
        }
        public void Create(KatastarskaOpstina katastarskaOpstina)
        {

            if (katastarskaOpstina == null) throw new ArgumentNullException(nameof(katastarskaOpstina));

            _context.KatastarskeOpstine.Add(katastarskaOpstina);
        }

        public void Delete(Guid katastarskaOpstinaId)
        {
            var katOpst = GetById(katastarskaOpstinaId);
            _context.Remove(katOpst);
        }

        public IEnumerable<KatastarskaOpstina> GetAll()
        {
            return _context.KatastarskeOpstine.ToList();
        }

        public KatastarskaOpstina GetById(Guid katastarskaOpstinaId)
        {
            return _context.KatastarskeOpstine.FirstOrDefault(p => p.KatastarskaOpstinaId == katastarskaOpstinaId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(KatastarskaOpstina katastarskaOpstina)
        {
            //nije potrebna implementacija
        }
    }
}
