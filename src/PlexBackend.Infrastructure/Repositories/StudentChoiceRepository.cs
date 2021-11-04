using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure;
using PlexBackend.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Repositories
{
    public class StudentChoiceRepository : Repository<StudentChoice>, IStudentChoiceRepository
    {
        private readonly PlexContext _context;

        public StudentChoiceRepository(PlexContext plexContext) : base(plexContext)
        {
            _context = plexContext;
        }
    }
}
