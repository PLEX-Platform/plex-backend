using PlexBackend.Core.Interfaces;
using PlexBackend.Core.Repositories.Base;
using PlexBackend.Infrastructure;
using PlexBackend.Infrastructure.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Repositories
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
