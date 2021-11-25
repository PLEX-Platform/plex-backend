using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PlexBackend.Core.Services
{
    public class MatchMakingService : IMatchMakingService
    {
        private readonly IStudentChoiceRepository _studentChoiceRepository;

        public MatchMakingService(IStudentChoiceRepository studentChoiceRepository)
        {
            _studentChoiceRepository = studentChoiceRepository;
        }

        public Dictionary<Project, Dictionary<Student, int>> CreateAlgorithmData()
        {
            List<StudentChoice> studentChoices = _studentChoiceRepository.FindAllWithProjectsAndStudents();

            Dictionary<Project, Dictionary<Student, int>> choicesPerProject = new();
            List<Project> projects = new();

            foreach (StudentChoice sc in studentChoices)
            {
                if (!projects.Contains(sc.Project))
                {
                    projects.Add(sc.Project);
                }
            }
            
            foreach (Project project in projects)
            {
                IEnumerable<StudentChoice> choices = studentChoices.Where(choice => choice.Project == project);

                Dictionary<Student, int> studentPriorityRank = choices.ToDictionary(sc => sc.Student, sc => sc.PriorityRank);

                choicesPerProject.Add(project, studentPriorityRank);
            }

            return choicesPerProject;
        }
    }
}
