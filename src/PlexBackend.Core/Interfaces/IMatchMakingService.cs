using PlexBackend.Core.Entities;
using System.Collections.Generic;

namespace PlexBackend.Core.Interfaces
{
    public interface IMatchMakingService
    {
        public Dictionary<Project, Dictionary<Student, int>> CreateAlgorithmData();
    }
}
