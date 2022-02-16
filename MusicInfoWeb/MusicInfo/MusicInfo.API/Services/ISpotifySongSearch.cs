using MusicInfo.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicInfo.API.Services
{
    public interface ISpotifySongSearch
    {
        Task<IEnumerable<Song>> GetResults(string searchQuery, string searchType, string countryCode, int limit, string acessToken);
    }
}
