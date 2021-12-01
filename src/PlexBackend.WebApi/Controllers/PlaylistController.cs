using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistService playlistService, IMapper mapper)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        // GET: api/<PlaylistController>
        [HttpGet]
        public ActionResult<IEnumerable<RetrievePlaylistViewModel>> Get()
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetAllPlaylists().Result.ToList();
                List<RetrievePlaylistViewModel> result = _mapper.Map<List<Playlist>, List<RetrievePlaylistViewModel>>(playlists);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public ActionResult<RetrievePlaylistViewModel> Get(int id)
        {
            try
            {
                Playlist playlist = _playlistService.GetPlaylistWithProjectsById(id).Result;
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
        public ActionResult<CreatePlaylistViewModel> Post([FromBody] CreatePlaylistViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return Created("Get", vm);
            }

            return BadRequest();
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
