using SkiServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SkiServiceApp.ViewModels
{
    public class BackendService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _backendUrl = "https://localhost:7285/SkiService"; // Ihre Backend-URL hier einfügen

        public async Task<List<ServiceOrder>> LoadServiceOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_backendUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<List<ServiceOrder>>(content);
                    return orders;
                }
                else
                {
                    // Handle error cases if needed
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                return null;
            }
        }
    }
}

