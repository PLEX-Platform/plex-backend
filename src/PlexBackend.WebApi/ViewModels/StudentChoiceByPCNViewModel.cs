using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class StudentChoiceByPCNViewModel
    {
        public int StudentPCN { get; set; }
        public List<ProjectPriority> ProjectPriorities { get; set; }

        public StudentChoiceByPCNViewModel(int PCN)
        {
            StudentPCN = PCN;
            ProjectPriorities = new List<ProjectPriority>();
        }

        public StudentChoiceByPCNViewModel()
        {
            ProjectPriorities = new List<ProjectPriority>();
        }
    }
}
