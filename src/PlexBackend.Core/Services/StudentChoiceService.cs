using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PlexBackend.Core.Services
{
    public class StudentChoiceService : IStudentChoiceService
    {
        private readonly IStudentChoiceRepository studentChoiceRepository;

        public StudentChoiceService(IStudentChoiceRepository studentChoiceRepository)
        {
            this.studentChoiceRepository = studentChoiceRepository;
        }

        public void AddRange(List<StudentChoice> studentChoices)
        {
                studentChoiceRepository.AddRange(studentChoices);
                studentChoiceRepository.Save();
        }

        public List<StudentChoice> FindAll()
        {
            return studentChoiceRepository.FindAll().ToList();
        }

        public StudentChoice GetById(int Id)
        {
            return studentChoiceRepository.GetById(Id);
        }

        public List<StudentChoice> FindByCondition(Expression<Func<StudentChoice, bool>> expression)
        {
            return studentChoiceRepository.FindByCondition(expression).ToList();
        }

        public bool DeleteStudentChoice(Guid Id)
        {
            StudentChoice studentChoice = studentChoiceRepository.GetById(Id);

            if (studentChoice == null)
            {
                return false;
            }
            
            studentChoiceRepository.Delete(studentChoice);
            studentChoiceRepository.Save();
            
            return true;
        }

        public Dictionary<Project, Dictionary<Student, int>> CreateAlgorithmData()
        {
            //List<StudentChoice> studentChoices = studentChoiceRepository.FindAllWithProjectsAndStudents();

            //Dictionary<Project, Dictionary<Student, int>> ChoicesPerProject = new Dictionary<Project, Dictionary<Student, int>>();
            //List<Project> projects = new List<Project>();

            //foreach (StudentChoice sc in studentChoices)
            //{
            //    if (!projects.Contains(sc.Project))
            //    {
            //        projects.Add(sc.Project);
            //    }
            //}

            //Dictionary<Student, int> students = new Dictionary<Student, int>();

            //foreach (Project project in projects)
            //{
            //    foreach (StudentChoice sc in studentChoices)
            //    {
            //        if (sc.Project == project)
            //        {
            //            students.Add(sc.Student, sc.PriorityRank);
            //        }
            //    }

            //    ChoicesPerProject.Add(project, students);
            //}

            //return ChoicesPerProject;
            return new Dictionary<Project, Dictionary<Student, int>>();
        }
    }
}
