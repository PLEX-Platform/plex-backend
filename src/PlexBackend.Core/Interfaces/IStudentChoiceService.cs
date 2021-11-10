using PlexBackend.Core.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IStudentChoiceService
    {
        void AddRange(List<StudentChoice> studentChoices);
        List<StudentChoice> FindAll();
        StudentChoice GetById(Guid Id);
        List<StudentChoice> FindByCondition(Expression<Func<StudentChoice, bool>> expression);
        bool DeleteStudentChoice(Guid Id);
    }
}
