using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System.Collections.Generic;
using System;

namespace ParcelaService.Data
{
    public interface IZasticenaZonaRepo
    {
        IEnumerable<ZasticenaZona> GetAll();
        ZasticenaZona GetById(Guid zasticenaZonaId);
        void Create(ZasticenaZona zasticenaZona);
        void Update(ZasticenaZona zasticenaZona);
        void Delete(Guid zasticenaZonaId);
        bool SaveChanges();
        public IEnumerable<DozvoljeniRad> GetDozvoljeniRadovi(Guid zasticenaZonaId);
    }
}
