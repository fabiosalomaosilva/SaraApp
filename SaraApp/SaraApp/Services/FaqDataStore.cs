using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaraApp.Models;

namespace SaraApp.Services
{
    public class FaqDataStore
    {
        HttpClient _client;
        IEnumerable<Faq> lista;

        public FaqDataStore()
        {
            _client = new HttpClient();

            lista = new List<Faq>();
        }

        public async Task<IEnumerable<Faq>> GetItemsAsync(bool forceRefresh = false)
        {

            var json = await _client.GetStringAsync($"{App.BackendUrl}/api/faqs");
            lista = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Faq>>(json));

            return lista;
        }

        public async Task<Faq> GetItemAsync(string id)
        {
            var json = await _client.GetStringAsync($"api/faqs/{id}");
            var faq = await Task.Run(() => JsonConvert.DeserializeObject<Faq>(json));

            return faq;
        }
    }
}