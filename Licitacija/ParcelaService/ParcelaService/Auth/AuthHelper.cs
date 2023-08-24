using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Auth
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration _configuration;

        public AuthHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
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
