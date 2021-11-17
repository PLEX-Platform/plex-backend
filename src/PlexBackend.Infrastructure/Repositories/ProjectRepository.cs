using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly PlexContext plexContext;

        public ProjectRepository(PlexContext plexContext) : base(plexContext)
        {
            this.plexContext = plexContext;
        }
    }
}
