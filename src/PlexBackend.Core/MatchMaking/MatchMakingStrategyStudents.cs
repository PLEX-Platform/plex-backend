using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    class MatchMakingStrategyStudents : IMatchMakingStrategy
    {
        private readonly ChoicesPerStudent _choices;
        private readonly int _maxMembersPerGroup;

        public MatchMakingStrategyStudents(ChoicesPerStudent choices, int maxMembersPerGroup)
        {
            _choices = choices;
            _maxMembersPerGroup = maxMembersPerGroup;
        }

        public Dictionary<Project, List<Student>> Execute()
        {
            foreach ((Student s, List<KeyValuePair<Project, int>> kvp) in _choices)
            {
                foreach ((Project p, int position) in kvp)
                {

                }
            }

            return null;
        }

      
    }
}
