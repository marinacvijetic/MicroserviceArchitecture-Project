namespace KupacService.Models.Prioritet
{
    /// <summary>
    /// DTO za potvrdu prioriteta.
    /// </summary>
    public class PrioritetDTOConfirmation
    {
        /// <summary>
        /// Identifikaciona oznaka prioriteta.
        /// </summary>
        public int PrioritetID { get; set; }

        /// <summary>
        /// Razlog zbog kog je kupac prioritet.
        /// </summary>
        public string PrioritetIzbor { get; set; }
    }
}
