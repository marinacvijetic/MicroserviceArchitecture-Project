using System;

namespace KupacService.Models.BrojTable
{
    /// <summary>
    /// DTO za broj table
    /// </summary>
    public class BrojTableDTO
    {
        /// <summary>
        /// Jedinstveni identifikator broja table.
        /// </summary>
        public Guid BrojTableID { get; set; }

        /// <summary>
        /// Broj table.
        /// </summary>
        public int Broj { get; set; }

    }
}
