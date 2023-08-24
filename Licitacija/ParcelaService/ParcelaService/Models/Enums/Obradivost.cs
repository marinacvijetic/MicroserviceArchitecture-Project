using System.ComponentModel;

namespace ParcelaService.Models.Enums
{
    /// <summary>
    /// Predstavlja realni entitet Obradivosti u vidu enumeratora.
    /// </summary>
    public enum Obradivost
    {
        [Description("Obradivo")] Obradivo,
        [Description("Ostalo")] Ostalo
    }
}
