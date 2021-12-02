using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IProjectService
    {
        ValidateProjectExists CheckIfProjectExists(int DexId);
        void AddNewProject(Project project);
        List<Project> GetAllProjects();

        Task<List<Project>> SaveNewProjects(List<Project> projects);
    }
}
