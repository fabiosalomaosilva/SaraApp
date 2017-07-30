using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaraApp.Models;

namespace SaraApp.Services
{
    public class PatologiaDataStore
    {
        HttpClient _client;
        IEnumerable<Patologia> patologias;

        public PatologiaDataStore()
        {
            _client = new HttpClient();

            patologias = new List<Patologia>();
        }

        public async Task<IEnumerable<Patologia>> GetItemsAsync(bool forceRefresh = false)
        {

            var json = await _client.GetStringAsync($"{App.BackendUrl}/api/patologias");
            patologias = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Patologia>>(json));

            return patologias;
        }

        public async Task<Patologia> GetItemAsync(string id)
        {
            var json = await _client.GetStringAsync($"api/patologias/{id}");
            var patologia = await Task.Run(() => JsonConvert.DeserializeObject<Patologia>(json));

            return patologia;
        }
    }
}
