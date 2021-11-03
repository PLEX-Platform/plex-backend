using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class StudentSubmitChoiceViewModel
    {
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "PCN must be greater than zero")]
        public int StudentPCN { get; set; }
        [Required]
        [EnsureOneElement(ErrorMessage = "At least one choice is required")]
        [EnsureUniqueProjectId(ErrorMessage = "A ProjectId may only occur once")]
        [EnsureUniquePriorityRank(ErrorMessage = "A Priorityrank may only occur once")]
        [EnsurePriorityRanksAreIncremental(ErrorMessage = "One or more priorityranks are missing")]
        public List<ProjectPriority> ProjectPriorities { get; set; }
    }
}
