using System;
using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DEXId { get; set; }
        public string Title { get; set; }
        public int MaximumNumberOfMembers { get; set; }
    }
}