using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class CreatePlaylistViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EnsureOneElement(ErrorMessage = "Playlist must contain atleast one project")]
        public List<ProjectSubmitViewModel> Projects { get; set; }
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Maximum amount of members must be greater than zero")]
        public int MaximumNumberOfStudentsPerProject { get; set; }
    }
}
