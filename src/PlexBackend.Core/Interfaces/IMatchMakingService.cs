using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IMatchMakingService
    {
        public Dictionary<Project, Dictionary<Student, int>> CreateAlgorithmData();
    }
}
