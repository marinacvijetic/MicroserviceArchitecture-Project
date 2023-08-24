using Microsoft.Extensions.Configuration;
using Licitacija1.DTOs;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Licitacija1.SyncDataServices.Http
{
    public class HttpJavnoNadmetanjeDataClient : IJavnoNadmetanjeDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpJavnoNadmetanjeDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<List<JavnoNadmetanjeDTO>> GetJavnaNadmetanjaByLicitacijaID()
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri url = new Uri($"{_configuration["Services:JavnoNadmetanje"] }api/javnoNadmetanje");
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<List<JavnoNadmetanjeDTO>>(content);
                }
                return default;
            }
            catch
            {
                return default;
            }
        }
    }
}
