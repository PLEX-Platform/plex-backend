using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.Core.MatchMaking;
using PlexBackend.WebApi.ViewModels;

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/project-groups")]
    [ApiController]
    public class ProjectGroupController : ControllerBase
    {
        private readonly IMatchMakingService _matchMakingService;

        public ProjectGroupController(IMatchMakingService matchMakingService)
        {
            _matchMakingService = matchMakingService;
        }
        /// <summary>
        ///     Get all the projectgroups
        /// </summary>
        [Route("/{playlistId:int}/matchmaker")]
        [HttpPost]
        public ActionResult<IEnumerable<ProjectGroupsMatchMakingViewModel>> RunMatchmaker(int playlistId)
        {
            Dictionary<Project, Dictionary<Student, int>> choicesPerProject = _matchMakingService.CreateAlgorithmData();
            IMatchMakingStrategy matchMakingStrategy = new MatchMakingStrategy(choicesPerProject, false);
            MatchMaker matchMaker = new(matchMakingStrategy);
            Dictionary<Project,List<Student>> result = matchMaker.Operate();
            IEnumerable<ProjectGroupsMatchMakingViewModel> projectGroupsMatchMakingViewModels = result.Select(pair => new ProjectGroupsMatchMakingViewModel
            {
                Project = pair.Key,
                Students = pair.Value
            });
            return Ok(projectGroupsMatchMakingViewModels);
        }
    }
}
