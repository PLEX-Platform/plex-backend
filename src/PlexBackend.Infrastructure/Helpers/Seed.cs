using Bogus;
using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Helpers
{
    public static class Seed
    {
        /// <summary>
        /// Create a list of students with random names and studentnumber
        /// </summary>
        public static List<Student> SeedStudents()
        {
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 5; i++)
            {
                Faker<Student> studentToFake = new Faker<Student>()
                    .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                    .RuleFor(s => s.LastName, f => f.Name.LastName())
                    .RuleFor(s => s.StudentNumber, f => f.Random.Number(100000, 999999));

                Student student = studentToFake.Generate();
                students.Add(student);
            }

            return students;
        }

        /// <summary>
        /// Create a list of projects with a random title
        /// </summary>
        public static List<Project> SeedProjects()
        {
            List<Project> projects = new List<Project>();
            {
                for (int i = 1; i <= 5; i++)
                {
                    Faker<Project> projectToFake = new Faker<Project>()
                        .RuleFor(s => s.Title, f => f.Commerce.ProductName());

                    Project project = projectToFake.Generate();
                    project.DEXId = i;
                    project.MaximumNumberOfMembers = 3;

                    projects.Add(project);
                }

                return projects;
            }
        }

        /// <summary>
        /// Create a list of studentchoices
        /// </summary>
        public static List<StudentChoice> SeedStudentChoices()
        {
            List<StudentChoice> studentChoices = new List<StudentChoice>();
            for (int i = 1; i <= 5; i++)
            {
                StudentChoice studentChoice = new StudentChoice
                {
                    StudentId = i,
                    ProjectId = i,
                    PriorityRank = 1,
                };

                studentChoices.Add(studentChoice);
            }

            return studentChoices;
        }

        /// <summary>
        /// Create a list of playlists with a random name and adds a list of projects to them
        /// </summary>
        /// <param name="projects">A list of projects.</param>
        public static List<Playlist> SeedPlaylists(List<Project> projects)
        {
            List<Playlist> playlists = new List<Playlist>();
            for (int i = 1; i <= 3; i++)
            {
                Faker<Playlist> playlistToFake = new Faker<Playlist>()
                    .RuleFor(s => s.Name, f => f.Commerce.ProductName());

                Playlist playlist = playlistToFake.Generate();
                playlist.Projects = projects;

                playlists.Add(playlist);
            }

            return playlists;
        }
    }
}
