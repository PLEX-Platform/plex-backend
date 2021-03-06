using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.Entities
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaximumNumberOfStudentsPerProject { get; set; }
        public List<Project> Projects { get; set; }
    }
}
