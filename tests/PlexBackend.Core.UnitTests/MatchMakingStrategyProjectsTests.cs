using System;
using System.Collections.Generic;
using PlexBackend.Core.Entities;
using PlexBackend.Core.MatchMaking;
using Xunit;

namespace PlexBackend.Core.UnitTests
{
    public class MatchMakingStrategyProjectsTests
    {
        [Fact]
        public void TwoStudentsTwoProjects_NoConflict()
        {
            ChoicesPerProject choicesPerProject = ChoicesBuilder.CreateBuilder()
                .NumberOfStudentsAndProjects(2, 2)
                .Choice(0, new[] {1, 0})
                .Choice(1, new[] {0, 1})
                .Build();
            IMatchMakingStrategy strategy = new MatchMakingStrategyProjects(choicesPerProject,  true);
            Dictionary<Project,List<Student>> result = strategy.Execute();
            Assert.Equal(result[choicesPerProject.GetProjectById(0)], new List<Student> {choicesPerProject.GetStudentByStudentNumber(1)});
            Assert.Equal(result[choicesPerProject.GetProjectById(1)], new List<Student> {choicesPerProject.GetStudentByStudentNumber(0)});
        }
        
        [Fact]
        public void ThreeStudentsTwoProjects_NoConflict()
        {
            ChoicesPerProject choicesPerProject = ChoicesBuilder.CreateBuilder()
                .NumberOfStudentsAndProjects(3, 2)
                .Choice(0, new[] {1, 0})
                .Choice(1, new[] {0, 1})
                .Choice(2, new[] {0, 1})
                .Build();

            IMatchMakingStrategy strategy = new MatchMakingStrategyProjects(choicesPerProject,  true);
            Dictionary<Project,List<Student>> result = strategy.Execute();
            Assert.Equal(result[choicesPerProject.GetProjectById(0)], new List<Student>
            {
                choicesPerProject.GetStudentByStudentNumber(1), choicesPerProject.GetStudentByStudentNumber(2)
            });
            Assert.Equal(result[choicesPerProject.GetProjectById(1)], new List<Student>{choicesPerProject.GetStudentByStudentNumber(0)});
        }
    }
}