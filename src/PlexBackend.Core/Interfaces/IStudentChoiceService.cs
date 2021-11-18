﻿using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PlexBackend.Core.Interfaces
{
    public interface IStudentChoiceService
    {
        void AddRange(List<StudentChoice> studentChoices);
        List<StudentChoice> FindAll();
        StudentChoice GetById(int Id);
        List<StudentChoice> FindByCondition(Expression<Func<StudentChoice, bool>> expression);
        public ValidateStudentExists VerifyUserExists(int PCN);
        bool DeleteStudentChoice(Guid Id);
    }
}
