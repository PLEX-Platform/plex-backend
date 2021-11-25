using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.Entities
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public List<Project> Projects { get; set; }
    }
}
