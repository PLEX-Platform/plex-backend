using PlexBackend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistWithProjectsById(int id);
    }
}
