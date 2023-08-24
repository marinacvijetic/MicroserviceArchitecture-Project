namespace KupacService.Models.Prioritet
{
    /// <summary>
    /// DTO za prioritet.
    /// </summary>
    public class PrioritetDTO
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
