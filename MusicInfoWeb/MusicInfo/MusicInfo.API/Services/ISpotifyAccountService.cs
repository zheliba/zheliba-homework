using System.Threading.Tasks;

namespace MusicInfo.API.Services
{
    public interface ISpotifyAccountService
    {
        Task<string> GetToken(string clientId, string clientSecret);
    }
}
