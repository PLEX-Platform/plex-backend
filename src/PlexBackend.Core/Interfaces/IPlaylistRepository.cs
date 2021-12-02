using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlexBackend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<IEnumerable<Playlist>> GetAllPlaylistsWithProjects();
        Task<Playlist> GetPlaylistWithProjectsById(int id);
    }
}
