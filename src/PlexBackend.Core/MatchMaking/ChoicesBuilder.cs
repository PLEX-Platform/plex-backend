using System;
using System.Collections.Generic;
using PlexBackend.Core.Entities;
using PlexBackend.Core.MatchMaking;

namespace PlexBackend.Core.MatchMaking
{
    public class ChoicesBuilder : IStudentsAndProjectsSelectionStage, IChoiceSelectionSelectionStage
    {
        private readonly List<Student> _students = new List<Student>();
        private readonly List<Project> _projects = new List<Project>();
        private readonly ChoicesPerProject _choicesPerProject = new ChoicesPerProject();
        private readonly Dictionary<int, int[]> _choices = new Dictionary<int, int[]>();
        
        private ChoicesBuilder(){}

        public static IStudentsAndProjectsSelectionStage CreateBuilder()
        {
            return new ChoicesBuilder();
        }

        public IChoiceSelectionSelectionStage Choice(int studentNumber, int[] projectRanking)
        {
            if (_students.Find(x => x.StudentNumber == studentNumber) is null)
            {
                throw new InvalidOperationException("Could not find student. Try to use a different student number or add more students first.");
            }

            if (projectRanking.Length < _projects.Count)
            {
                throw new InvalidOperationException("Too little project rankings provided.");
            }
            
            if (_choices.ContainsKey(studentNumber))
            {
                throw new InvalidOperationException("Trying to add a student id which already exists.");
            }

            _choices[studentNumber] = projectRanking;
            return this;
        }

        public ChoicesPerProject Build()
        {
            foreach (Project project in _projects)
            {
                _choicesPerProject[project] = new Dictionary<Student, int>();
                foreach (Student student in _students)
                {
                    // the ranking of the projects by a student
                    _choicesPerProject[project][student] = _choices[student.StudentNumber][project.Id];
                }
            }
            return _choicesPerProject;
        }
        
        public IChoiceSelectionSelectionStage NumberOfStudentsAndProjects(int students, int projects)
        {
            for (int i = 0; i < students; i++)
            {
                _students.Add(new Student(){StudentNumber = i});
            }
            
            for (int i = 0; i < projects; i++)
            {
                _projects.Add(new Project(){Id = i});
            }

            return this;
        }
    }
    
    public interface IStudentsAndProjectsSelectionStage
    {
        public IChoiceSelectionSelectionStage NumberOfStudentsAndProjects(int students, int projects);
    }

    public interface IChoiceSelectionSelectionStage
    {
        IChoiceSelectionSelectionStage Choice(int studentNumber, int[] projectRanking);
        ChoicesPerProject Build();
    }
}