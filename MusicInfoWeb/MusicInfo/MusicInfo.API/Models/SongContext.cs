using Microsoft.EntityFrameworkCore;

namespace MusicInfo.API.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Song> Songs { get; set; }
    }
}
