using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaraApp.Models;

namespace SaraApp.Services
{
    public class AreaDataStore
    {
        HttpClient _client;
        IEnumerable<Area> areas;

        public AreaDataStore()
        {
            _client = new HttpClient();

            areas = new List<Area>();
        }

        public async Task<IEnumerable<Area>> GetItemsAsync(bool forceRefresh = false)
        {

            var json = await _client.GetStringAsync($"{App.BackendUrl}/api/areas");
            areas = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Area>>(json));

            return areas;
        }

        public async Task<Area> GetItemAsync(string id)
        {
            var json = await _client.GetStringAsync($"api/areas/{id}");
            var area = await Task.Run(() => JsonConvert.DeserializeObject<Area>(json));

            return area;
        }
    }
}