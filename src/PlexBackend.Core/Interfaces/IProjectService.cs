using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IProjectService
    {
        Task<Project> AddNewProject(Project project);
        Task<List<Project>> SaveNewProjects(List<Project> projects);
    }
}
