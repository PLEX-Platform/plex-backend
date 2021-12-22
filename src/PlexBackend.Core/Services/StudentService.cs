using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class StudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public bool VerifyUserExists(int PCN)
        {
            if (studentRepository.FindByCondition(student => student.StudentNumber == PCN) == null)
            {
                return false;
            }
            return true;
        }
    }
}
