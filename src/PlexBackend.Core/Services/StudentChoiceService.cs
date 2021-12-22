using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class StudentChoiceService : IStudentChoiceService
    {
        private readonly IStudentChoiceRepository _studentChoiceRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IProjectRepository _projectRepository;

        public StudentChoiceService(IStudentChoiceRepository studentChoiceRepository, IStudentRepository studentRepository, IProjectRepository projectRepository)
        {
            _studentChoiceRepository = studentChoiceRepository;
            _studentRepository = studentRepository;
            _projectRepository = projectRepository;
        }

        public void AddRange(List<StudentChoice> studentChoices)
        {
            foreach (StudentChoice sc in studentChoices)
            {
                sc.Project = _projectRepository.FindByCondition(e => e.DEXId == sc.ProjectId).FirstOrDefault();
                sc.ProjectId = sc.Project.Id;
            }
            
            _studentChoiceRepository.AddRange(studentChoices);
            _studentChoiceRepository.Save();
        }

        public async Task<IEnumerable<StudentChoice>> FindAll()
        {
            return await _studentChoiceRepository.FindAll();
        }

        public StudentChoice GetById(int Id)
        {
            return _studentChoiceRepository.GetById(Id);
        }

        public List<StudentChoice> FindByCondition(Expression<Func<StudentChoice, bool>> expression)
        {
            return _studentChoiceRepository.FindByCondition(expression).ToList();
        }

        public bool DeleteStudentChoice(Guid Id)
        {
            StudentChoice studentChoice = _studentChoiceRepository.GetById(Id);

            if (studentChoice == null)
            {
                return false;
            }
            
            _studentChoiceRepository.Delete(studentChoice);
            _studentChoiceRepository.Save();
            
            return true;
        }

        public ValidateStudentExists VerifyUserExists(int PCN)
        {
            Student student = _studentRepository.GetStudentByPCN(PCN);

            if (student == null)
            {
                return new ValidateStudentExists
                {
                    Exists = false,
                    Student = student
                };
            }

            return new ValidateStudentExists
            {
                Exists = true,
                Student = student
            };
                
        }
    }
}
