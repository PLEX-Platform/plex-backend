using System;
using System.Collections.Generic;
using System.Linq;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    public class MatchMakingStrategy : IMatchMakingStrategy
    {
        //The ranking of the projects students have chosen
        private readonly Dictionary<Project, Dictionary<Student, int>> _choices;
        
        //List to return result
        private readonly Dictionary<Project, List<Student>> _result = new();

        private readonly bool _isTesting;
        
        
        /// <summary>
        /// Constructor for the matchmaking algorithm
        /// </summary>
        /// <param name="choices">List of projects and the ranking that a student has divided them into.</param>
        /// <param name="isTesting">Check whether program is runned via unit test or not</param>
        public MatchMakingStrategy(IDictionary<Project, Dictionary<Student, int>> choices, bool isTesting)
        {
            _choices = new Dictionary<Project, Dictionary<Student, int>>(choices);
            _isTesting = isTesting;
        }
        
        
        /// <summary>
        /// Runs the matchmaking algorithm
        /// </summary>
        /// <returns></returns>
        public Dictionary<Project, List<Student>> Execute()
        {
            foreach ((Project project, Dictionary<Student, int> studentRankings) in _choices)
            {
                _result[project] = new List<Student>();
                
                if (_choices[project].Count == 0)
                {
                    break;
                }
                PutStudentsInProjectWhoRankedThisProjectTheHighest(project, 
                    _choices[project].Values.Min());

                if (!_isTesting)
                {
                    RemoveExcessStudentsRandomlyFromProject(project);
                }
                else
                {
                    RemoveLowestStudentNumberFromProject(project);
                }
                
                RemoveStudentsFromChoicesPoolWhoAreLockedIn(project);
            }
            return _result;
        }
        
        /// <summary>
        /// Check which students ranked the given project as the highest and place them in that group.
        /// </summary>
        /// <param name="project">The project to check for which students rated it highest</param>
        /// <param name="highestRanking">The highest ranking that a student has given this project</param>
        private void PutStudentsInProjectWhoRankedThisProjectTheHighest(Project project, int highestRanking)
        {
            Dictionary<Student, int> projectRankingByStudent = _choices[project];
            foreach ((Student student, int ranking) in projectRankingByStudent)
            {
                if (ranking == highestRanking)
                {
                    _result[project].Add(student);
                }
            }
        }
        
        /// <summary>
        /// Removes students from the list if the number of project members exceeds the maximum number allowed. Selection of students to remove is random.
        /// </summary>
        /// <param name="project">The project that exceeds the maximum number of members.</param>
        private void RemoveExcessStudentsRandomlyFromProject(Project project)
        {
            if (_result[project].Count <= project.MaximumNumberOfMembers)
            {
                return;
            }
            Random random = new Random(69);
            List<Student> studentsWhoAreChosenToStay = new();
            for (int i = 0; i < project.MaximumNumberOfMembers; i++)
            {
                int nextStudentWhoCanStay = random.Next(0, project.MaximumNumberOfMembers + 1);
                studentsWhoAreChosenToStay.Add(_choices[project].Keys.ToList()[nextStudentWhoCanStay]);
            }

            _result[project] = studentsWhoAreChosenToStay;
        }

        private void RemoveLowestStudentNumberFromProject(Project project)
        {
            if (_result[project].Count <= project.MaximumNumberOfMembers)
            {
                return;
            }

            List<Student> selectedStudents = new();
            for (int x = 0; x < project.MaximumNumberOfMembers; x++)
            {
                var studentWithHighestNumber = _choices[project].Keys.ToList()[_choices[project].Values.Max()];
                selectedStudents.Add(studentWithHighestNumber);
                _choices[project].Remove(studentWithHighestNumber);
            }

            _result[project] = selectedStudents;
        }

        /// <summary>
        /// Removes students from the list that have already been confirmed for a specific project.
        /// </summary>
        /// <param name="project"></param>
        private void RemoveStudentsFromChoicesPoolWhoAreLockedIn(Project project)
        {
            foreach (Student student in _result[project])
            {
                foreach ((Project _, Dictionary<Student, int> poolPerStudent) in _choices)
                {
                    poolPerStudent.Remove(student);
                }
            }
        }

        
        
    }
}