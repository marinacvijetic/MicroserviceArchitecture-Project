namespace KupacService.Helpers
{
    /// <summary>
    /// Interfejs za autorizaciju
    /// </summary>
    public interface IAuthHelper
    {
        /// <summary>
        /// Potpis metode
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Authorize(string key);

    }
}
