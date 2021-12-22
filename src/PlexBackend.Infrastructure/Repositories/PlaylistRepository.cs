using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly PlexContext _context;

        public PlaylistRepository(PlexContext plexContext) : base(plexContext)
        {
            this._context = plexContext;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsWithProjects()
        {
            return await _context.Playlists
                .Include(p => p.Projects)
                .ToListAsync();
        }

        public async Task<Playlist> GetPlaylistWithProjectsById(int id)
        {
            return await _context.Playlists
                .Include(p => p.Projects)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
