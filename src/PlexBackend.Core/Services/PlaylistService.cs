using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            return await _playlistRepository.GetAllPlaylistsWithProjects();
        }

        public async Task<Playlist> GetPlaylistWithProjectsById(int id)
        {
            return await _playlistRepository.GetPlaylistWithProjectsById(id);
        }

        public async Task<Playlist> SavePlaylist(Playlist playlist)
        {
            await _playlistRepository.SavePlaylist(playlist);
            await _playlistRepository.Save();
            return playlist;
        }
    }
}
