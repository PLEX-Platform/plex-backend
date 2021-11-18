using System.Collections.Generic;
using PlexBackend.Core.Entities;

namespace PlexBackend.WebApi.ViewModels
{
    public class ProjectGroupsMatchMakingViewModel
    {
        public Project Project { get; set; }
        public List<Student> Students { get; set; }
    }
}