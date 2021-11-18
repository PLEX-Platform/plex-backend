﻿using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PlexBackend.Core.Services
{
    public class StudentChoiceService : IStudentChoiceService
    {
        private readonly IStudentChoiceRepository studentChoiceRepository;
        private readonly IStudentRepository studentRepository;

        public StudentChoiceService(IStudentChoiceRepository studentChoiceRepository, IStudentRepository studentRepository)
        {
            this.studentChoiceRepository = studentChoiceRepository;
            this.studentRepository = studentRepository;
        }

        public void AddRange(List<StudentChoice> studentChoices)
        {
                studentChoiceRepository.AddRange(studentChoices);
                studentChoiceRepository.Save();
        }

        public List<StudentChoice> FindAll()
        {
            return studentChoiceRepository.FindAll().ToList();
        }

        public StudentChoice GetById(int Id)
        {
            return studentChoiceRepository.GetById(Id);
        }

        public List<StudentChoice> FindByCondition(Expression<Func<StudentChoice, bool>> expression)
        {
            return studentChoiceRepository.FindByCondition(expression).ToList();
        }

        public bool DeleteStudentChoice(Guid Id)
        {
            StudentChoice studentChoice = studentChoiceRepository.GetById(Id);

            if (studentChoice == null)
            {
                return false;
            }
            
            studentChoiceRepository.Delete(studentChoice);
            studentChoiceRepository.Save();
            
            return true;
        }

        public ValidateStudentExists VerifyUserExists(int PCN)
        {
            Student student = studentRepository.GetStudentByPCN(PCN);

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
