using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;

namespace UplataService.Data
{
    public interface IUplataRep
    {
        bool SaveChanges();

        IEnumerable<Uplata> GetAllUplate(Guid? kupacId);

        Uplata GetUplataById(Guid id);

        void CreateUplata(Uplata uplata);

        void UpdateUplata(Uplata zalba);

        void DeleteUplata(Guid id);
    }
}
