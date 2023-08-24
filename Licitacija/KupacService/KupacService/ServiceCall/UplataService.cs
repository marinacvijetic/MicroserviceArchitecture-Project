using KupacService.Models;
using KupacService.ServiceCall;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Servis za komunikaciju sa Uplatom
    /// </summary>
    public class UplataService : IUplataService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="httpClient"></param>
        public UplataService(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Get metoda za uplate
        /// </summary>
        /// <param name="kupacId"></param>
        /// <returns></returns>
        public async Task<ICollection<UplataDTO>> GetUplateByKupacID(Guid kupacId)
        {
            using var httpClient = new HttpClient();
            Uri url = new($"{_configuration["Services:UplataService"]}?kupacId={kupacId}");
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return string.IsNullOrEmpty(content) ? Array.Empty<UplataDTO>() : JsonConvert.DeserializeObject<ICollection<UplataDTO>>(content);
            }
            return Array.Empty<UplataDTO>();
        }

    }
}
