using System.ComponentModel;

namespace ParcelaService.Models.Enums
{
    /// <summary>
    /// Predstavlja realni entitet OblikaSvojine u vidu enumeratora.
    /// </summary>
    public enum OblikSvojine
    {
        [Description("Privatna svojina")] PrivatnaSvojina,
        [Description("Drzavna svojina RS")] DrzavnaSvojinaRS,
        [Description("Drzavna svojina")] DrzavnaSvojina,
        [Description("Drustvena svojina")] DrustvenaSvojina,
        [Description("Zadruzna svojina")] ZadruznaSvojina,
        [Description("Mesovita svojina")] MesovitaSvojina,
        [Description("Drugi oblici")] DrugiOblici
    }
}
