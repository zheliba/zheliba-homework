using MusicInfo.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicInfo.API.Services
{
    public class SpotifySongSearch : ISpotifySongSearch
    {
        private readonly HttpClient _httpClient;
        public SpotifySongSearch(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<Song>> GetResults(string searchQuery, string searchType, string countryCode, int limit, string acessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acessToken);

            var response = await _httpClient.GetAsync($"search?q={searchQuery}&type={searchType}&market={countryCode}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetSearchResult>(responseStream);

            return responseObject?.tracks?.items.Select(i => new Song
            {
                Id = i.id,
                Title = i.name,
                Artists = string.Join(",", i.artists.Select(i =>i.name)),
                Duration = i.duration_ms.ToString()
            });
        }
    }
}
