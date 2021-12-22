using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi
{
    public class ProjectPriority
    {
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "ProjectId must be greater than zero")]
        public int ProjectId { get; set; }
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Priorityrank must be greater than zero")]
        public int PriorityRank { get; set; }
    }
}
