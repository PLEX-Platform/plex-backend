using System.Collections.Generic;
using PlexBackend.Core.Entities;
using PlexBackend.Core.MatchMaking;

namespace PlexBackend.WebApi.ViewModels
{
    public class ProjectGroupsViewModel
    {
        public ChoicesPerProject ChoicesPerProject { get; set; }
        public List<Student> UnassignedStudents { get; set; }
    }
}