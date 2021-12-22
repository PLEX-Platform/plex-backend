using System.Collections.Generic;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    public interface IMatchMakingStrategy
    {
        Dictionary<Project, List<Student>> Execute();
    }
}