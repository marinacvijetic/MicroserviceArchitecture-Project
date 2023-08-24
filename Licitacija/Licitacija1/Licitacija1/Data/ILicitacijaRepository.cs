using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Data
{
    public interface ILicitacijaRepository
    {
        bool SaveChanges();
        List<LicitacijaModel> GetLicitacije();

        LicitacijaModel GetLicitacijaByID(Guid licitacijaID);

        void CreateLicitacija(LicitacijaModel licitacija);

        void UpdateLicitacija(LicitacijaModel licitacija);

        void DeleteLicitacija(Guid licitacijaID);
    }
}
