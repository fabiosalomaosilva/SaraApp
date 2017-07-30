using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaraApp.Models;

namespace SaraApp.Services
{
    public class AcaoDataStore
    {
        HttpClient _client;
        IEnumerable<Acao> acoes;

        public AcaoDataStore()
        {
            _client = new HttpClient();

            acoes = new List<Acao>();
        }

        public async Task<IEnumerable<Acao>> GetItemsAsync(bool forceRefresh = false)
        {

            var json = await _client.GetStringAsync($"{App.BackendUrl}/api/acoes");
            acoes = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Acao>>(json));

            return acoes;
        }

        public async Task<Acao> GetItemAsync(string id)
        {
            var json = await _client.GetStringAsync($"api/acoes/{id}");
            var acao = await Task.Run(() => JsonConvert.DeserializeObject<Acao>(json));

            return acao;
        }
    }
}