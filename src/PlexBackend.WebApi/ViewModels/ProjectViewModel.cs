using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class ProjectViewModel
    {
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Id must be greater than zero")]
        public int Id { get; set; }
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Id must be greater than zero")]
        public int DEXId { get; set; }
        [Required]
        public string Title { get; set; }
        public int MaximumNumberOfMembers { get; set; }
    }
}
