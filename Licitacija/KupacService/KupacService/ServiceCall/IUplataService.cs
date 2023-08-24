using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KupacService.ServiceCall
{
    /// <summary>
    /// Interfejs za komunikaciju sa servisom Uplata
    /// </summary>
    public interface IUplataService
    {
        /// <summary>
        /// Potpis metode
        /// </summary>
        /// <param name="kupacID"></param>
        /// <returns></returns>
        public Task<ICollection<UplataDTO>> GetUplateByKupacID(Guid kupacID);
    }
}
