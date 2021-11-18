using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlexBackend.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly PlexContext plexContext;
        public StudentRepository(PlexContext plexContext) : base(plexContext)
        {
            this.plexContext = plexContext;
        }

        public Student GetStudentByPCN(int PCN)
        {
            return plexContext.Students.Where(student => student.StudentNumber == PCN).FirstOrDefault();
        }
    }
}
