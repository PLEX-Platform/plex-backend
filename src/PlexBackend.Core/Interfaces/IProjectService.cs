using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IProjectService
    {
        public ValidateProjectExists CheckIfProjectExists(int DexId);
        public void AddNewProject(Project project);
    }
}
