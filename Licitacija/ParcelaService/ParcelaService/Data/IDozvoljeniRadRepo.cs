using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System.Collections.Generic;
using System;

namespace ParcelaService.Data
{
    public interface IDozvoljeniRadRepo
    {
        IEnumerable<DozvoljeniRad> GetAll();
        DozvoljeniRad GetById(Guid dozvoljeniRadId);
        void Create(DozvoljeniRad dozvoljeniRad);
        void Update(DozvoljeniRad dozvoljeniRad);
        void Delete(Guid dozvoljeniRadId);
        bool SaveChanges();
    }
}
