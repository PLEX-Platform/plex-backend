using PlexBackend.Core.Entities;
using PlexBackend.Core.MatchMaking;
using Xunit;

namespace PlexBackend.Core.UnitTests
{
    public class ChoicesBuilderTest
    {
        [Fact]
        public void ShouldGetCorrectProject()
        {
            ChoicesPerProject choicesPerProject = ChoicesBuilder.CreateBuilder()
                .NumberOfStudentsAndProjects(2, 2)
                .Choice(0, new[] {1, 0})
                .Choice(1, new[] {0, 1})
                .Build();
            
            Assert.Equal(0, choicesPerProject.GetProjectById(0).Id);
            Assert.Equal(1, choicesPerProject.GetProjectById(1).Id);
        }

        [Fact]
        public void ShouldGetCorrectStudent()
        {
            ChoicesPerProject choicesPerProject = ChoicesBuilder.CreateBuilder()
                .NumberOfStudentsAndProjects(2, 2)
                .Choice(0, new[] {1, 0})
                .Choice(1, new[] {0, 1})
                .Build();
            Assert.Equal(0, choicesPerProject.GetStudentByStudentNumber(0).StudentNumber);
            Assert.Equal(1, choicesPerProject.GetStudentByStudentNumber(1).StudentNumber);
        }

        [Fact]
        public void ShouldHaveCorrectStudentQuantityInProjects()
        {
            ChoicesPerProject choicesPerProject = ChoicesBuilder.CreateBuilder()
                .NumberOfStudentsAndProjects(2, 2)
                .Choice(0, new[] {1, 0})
                .Choice(1, new[] {0, 1})
                .Build();

            Project project = choicesPerProject.GetProjectById(0);
            
            Assert.Contains(choicesPerProject[project].Keys, student => student.StudentNumber == 0);
            Assert.Contains(choicesPerProject[project].Keys, student => student.StudentNumber == 1);
        }
    }
}