using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using PlexBackend.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public async Task<Project> AddNewProject(Project project)
        {
            await _projectRepository.Create(project);
            await _projectRepository.Save();
            return project;
        }

        public async Task<List<Project>> SaveNewProjects(List<Project> projects)
        {
            List<int> DexIds = new List<int>();

            foreach (Project project in projects)
            {
                DexIds.Add(project.DEXId);
            }
            
            List<Project> existingProjects = _projectRepository.FindByCondition(x => DexIds.Contains(x.DEXId)).ToList();
            List<Project> newProjects = new List<Project>();
            List<Project> result = new List<Project>();

            foreach (Project proj in projects)
            {
                Project realProj = existingProjects.FirstOrDefault(e => e.DEXId == proj.DEXId);
                if (realProj == null)
                {
                    newProjects.Add(proj);
                }
                else
                {
                    result.Add(realProj);
                }
            }

            foreach (Project project1 in newProjects)
            {           
                result.Add(await this.AddNewProject(project1));
            }

            return result;
        }
    }
}
