using Microsoft.Extensions.Configuration;

namespace Dokument.Auth
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration _configuration;

        public AuthHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Metoda za proveru prava pristupa
        /// </summary>
        /// <param name="key">Parametar koji se prosledjuje prilikom poziva zahteva, sluzi za autorizaciju.</param>
        /// <returns></returns>
        public bool Authorize(string key)
        {
            if (key == null || !key.StartsWith("Bearer"))
            {
                return false;
            }
            var storedKey = _configuration.GetValue<string>("Authorization:Key");
            var finalKey = "Bearer " + storedKey;

            if (finalKey.Equals(key))
            {
                return true;
            }
            return false;
        }
    }
}
