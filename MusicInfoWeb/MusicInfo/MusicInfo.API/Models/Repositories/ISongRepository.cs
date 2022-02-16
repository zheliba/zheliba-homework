using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicInfo.API.Models.Repositories
{
    public interface ISongRepository
    {

        Task<IEnumerable<Song>> GetAll();
        Task<Song> Get(string id);
        Task<Song> Create(Song song);
    }
}
