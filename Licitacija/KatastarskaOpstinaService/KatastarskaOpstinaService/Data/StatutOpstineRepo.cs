using AutoMapper;
using KatastarskaOpstinaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatastarskaOpstinaService.Data
{
    public class StatutOpstineRepo : IStatutOpstineRepo
    {
        private readonly KatastarskaOpstinaDbContext _context;

        public StatutOpstineRepo(KatastarskaOpstinaDbContext context)
        {
            _context = context; 
        }
        public void Create(StatutOpstine statutOpstine)
        {
            if (statutOpstine == null) throw new ArgumentNullException(nameof(statutOpstine));

            _context.StatutiOpstina.Add(statutOpstine);
        }

        public void Delete(Guid statutOpstineId)
        {
            var statut = GetById(statutOpstineId);
            _context.Remove(statut);
        }

        public IEnumerable<StatutOpstine> GetAll()
        {
            return _context.StatutiOpstina.ToList();
        }

        public StatutOpstine GetById(Guid statutOpstineId)
        {
            return _context.StatutiOpstina.FirstOrDefault(p => p.StatutOpstineId == statutOpstineId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(StatutOpstine statutOpstine)
        {
            //Nije potrebno izvrsiti implementaciju metode
        }
    }
}
