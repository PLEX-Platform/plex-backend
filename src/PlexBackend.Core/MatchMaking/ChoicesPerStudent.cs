using System.Collections.Generic;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    public class ChoicesPerStudent : Dictionary<Student, List<KeyValuePair<Project, int>>>
    {
        
    }
}