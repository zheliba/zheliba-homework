using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicInfo.API.Models.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly SongContext _context;
        public SongRepository(SongContext context)
        {
            _context = context;
        }
        public async Task<Song> Create(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return song;
        }
        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> Get(string id)
        {
            return await _context.Songs.FindAsync(id);
        }
    }
}
