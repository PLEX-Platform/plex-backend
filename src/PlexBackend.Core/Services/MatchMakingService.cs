using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class MatchMakingService
    {
        private readonly IStudentChoiceRepository studentChoiceRepository;

        public MatchMakingService(IStudentChoiceRepository studentChoiceRepository)
        {
            this.studentChoiceRepository = studentChoiceRepository;
        }

        public Dictionary<Project, Dictionary<Student, int>> CreateAlgorithmData()
        {
            List<StudentChoice> studentChoices = studentChoiceRepository.FindAllWithProjectsAndStudents();

            Dictionary<Project, Dictionary<Student, int>> ChoicesPerProject = new Dictionary<Project, Dictionary<Student, int>>();
            List<Project> projects = new List<Project>();

            foreach (StudentChoice sc in studentChoices)
            {
                if (!projects.Contains(sc.Project))
                {
                    projects.Add(sc.Project);
                }
            }

            Dictionary<Student, int> students = new Dictionary<Student, int>();

            foreach (Project project in projects)
            {
                foreach (StudentChoice sc in studentChoices)
                {
                    if (sc.Project == project)
                    {
                        students.Add(sc.Student, sc.PriorityRank);
                    }
                }

                ChoicesPerProject.Add(project, students);
            }

            return ChoicesPerProject;
        }
    }
}
