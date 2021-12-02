using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public PlaylistController(IPlaylistService playlistService, IMapper mapper, IProjectService projectService)
        {
            _playlistService = playlistService;
            _mapper = mapper;
            _projectService = projectService;
        }

        // GET: api/<PlaylistController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RetrievePlaylistViewModel>>> Get()
        {
            try
            {
                IEnumerable<Playlist> playlists = await _playlistService.GetAllPlaylists();
                List<RetrievePlaylistViewModel> result = _mapper.Map<List<Playlist>, List<RetrievePlaylistViewModel>>(playlists.ToList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetrievePlaylistViewModel>> Get(int id)
        {
            try
            {
                Playlist playlist = await _playlistService.GetPlaylistWithProjectsById(id);
                if (playlist != null)
                {
                    RetrievePlaylistViewModel result = _mapper.Map<Playlist, RetrievePlaylistViewModel>(playlist);
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PlaylistController>
        [HttpPost]
        public async Task<ActionResult<RetrievePlaylistViewModel>> Post([FromBody] CreatePlaylistViewModel vm)
        {
            if (ModelState.IsValid && TryValidateModel(vm.Projects))
            {
                try
                {
                    Playlist playlist =  _mapper.Map<CreatePlaylistViewModel, Playlist>(vm);

                    playlist.Projects = await _projectService.SaveNewProjects(playlist.Projects);

                    //Save playlist to the db
                    playlist = await _playlistService.SavePlaylist(playlist);

                    RetrievePlaylistViewModel resultVm = _mapper.Map<Playlist, RetrievePlaylistViewModel>(playlist);
                    return CreatedAtAction(nameof(Get), new { id = playlist.Id}, resultVm);
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.InnerException.Message);
                }
            }

            return BadRequest("The input is not valid");
        }

        // PUT api/<PlaylistController>/5
        [HttpPut("{id}")]
        public ActionResult<CreatePlaylistViewModel> Put(int id, [FromBody] CreatePlaylistViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return Ok(vm);
            }

            return BadRequest();
        }

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
