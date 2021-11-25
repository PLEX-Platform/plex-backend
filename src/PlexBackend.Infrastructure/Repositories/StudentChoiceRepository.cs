using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlexBackend.Core.Entities;

namespace PlexBackend.Infrastructure.Repositories
{
    public class StudentChoiceRepository : Repository<StudentChoice>, IStudentChoiceRepository
    {
        private readonly PlexContext _context;

        public StudentChoiceRepository(PlexContext plexContext) : base(plexContext)
        {
            _context = plexContext;
        }

        public List<StudentChoice> FindAllWithProjectsAndStudents()
        {
            return _context.StudentChoices
                .Include(e => e.Project)
                .Include(e => e.Student).ToList();
        }
    }
}
