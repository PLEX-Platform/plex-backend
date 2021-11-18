using PlexBackend.Core.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IStudentChoiceRepository : IRepository<StudentChoice>
    {
        List<StudentChoice> FindAllWithProjectsAndStudents();
    }
}
