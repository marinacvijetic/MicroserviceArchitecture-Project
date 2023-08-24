using System.ComponentModel;

namespace ParcelaService.Models.Enums
{
    /// <summary>
    /// Predstavlja realni entitet Kulture u vidu enumeratora.
    /// </summary>
    public enum Kultura
    {
        [Description("Njive")] Njive,
        [Description("Vrtovi")] Vrtovi,
        [Description("Vocnjaci")] Vocnjaci,
        [Description("Vinogradi")] Vinogradi,
        [Description("Livade")] Livade,
        [Description("Pasnjaci")] Pasnjaci,
        [Description("Sume")] Sume,
        [Description("Trstici- mocvare")] TrsticiMocvare,
    }
}
