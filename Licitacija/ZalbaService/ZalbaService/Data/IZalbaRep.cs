using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public interface IZalbaRep
    {
        //Interfejs za repozitorijum zalba
        bool SaveChanges();

        IEnumerable<Zalba> GetAllZalbe();

        Zalba GetZalbaById(Guid id);

        void CreateZalba(Zalba zalba);

        void UpdateZalba(Zalba zalba);

        void DeleteZalba(Guid id);
    }
}
