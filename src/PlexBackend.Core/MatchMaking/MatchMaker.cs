using System.Collections.Generic;
using PlexBackend.Core.Entities;

namespace PlexBackend.Core.MatchMaking
{
    public class MatchMaker
    {
        private readonly IMatchMakingStrategy _strategy;

        public MatchMaker(IMatchMakingStrategy strategy)
        {
            _strategy = strategy;
        }

        public Dictionary<Project, List<Student>> Operate()
        {
            return _strategy.Execute();
        }
    }
}