using System;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Entities
{
    public class KupacOvlascenoLice
    {
        public Guid KupacID { get; set; }
        public Guid OvlascenoLiceID { get; set; }

        public Kupac Kupac { get; set; }
        public OvlascenoLice OvlascenoLice { get; set; }
    }
}
