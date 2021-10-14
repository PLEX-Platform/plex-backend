using System.Collections.Generic;
using System.Linq;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    public class ChoicesPerProject : Dictionary<Project, Dictionary<Student, int>>
    {
        public Project GetProjectById(int id)
        {
            return Keys.FirstOrDefault(project => project.Id == id);
        }

        public Student GetStudentByStudentNumber(int studentNumber)
        {
            return Values.SelectMany(ints => ints.Keys).FirstOrDefault(x => x.StudentNumber == studentNumber);
        }
    }

    public class ProjectRankPerStudent : Dictionary<Student, int>
    {
         
    }
}