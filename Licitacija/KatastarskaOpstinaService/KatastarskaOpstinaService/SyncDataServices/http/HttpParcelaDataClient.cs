using KatastarskaOpstinaService.DTOs;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using KatastarskaOpstinaService.Models;
using Newtonsoft.Json;

namespace KatastarskaOpstinaService.SyncDataServices.http
{
    public class HttpParcelaDataClient : IParcelaDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HttpParcelaDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<ParcelaDto>> GetParcelaForKatastarskaOpstina(Guid katastarskaOpstinaId)
        {
            using var httpClient = new HttpClient();
            var url = $"{_configuration["Services:ParcelaService"]}?katastarskaOpstinaId={katastarskaOpstinaId}";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<List<ParcelaDto>>(content);
            }
            return default;
        }
    }
}
