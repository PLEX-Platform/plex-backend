using PlexBackend.Infrastructure.ContextModels;
using PlexBackend.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Converter
{
    public static class ModelConverter
    {
        public static StudentChoiceByPCNViewModel ContextModelsToStudentChoiceByPCN (int PCN, List<StudentChoice> studentChoices)
        {
            if (studentChoices is null)
            {
                throw new ArgumentNullException(nameof(studentChoices));
            }

            StudentChoiceByPCNViewModel vm = new StudentChoiceByPCNViewModel(PCN);
            foreach (StudentChoice sc in studentChoices)
            {
                vm.ProjectPriorities.Add(new ProjectPriority
                {
                    PriorityRank = sc.PriorityRank,
                    ProjectId = sc.ProjectId,
                });
            }

            return vm;
        }
    }
}
