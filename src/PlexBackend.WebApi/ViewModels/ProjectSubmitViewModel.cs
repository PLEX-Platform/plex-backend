using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class ProjectSubmitViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Id must be greater than zero")]
        public int DEXId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Maximum amount of members must be greater than zero")]
        public int MaximumNumberOfMembers { get; set; }
    }
}
