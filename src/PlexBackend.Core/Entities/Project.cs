using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlexBackend.Core.Entities
{
    [Index(nameof(DEXId), IsUnique = true)]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int DEXId { get; set; }
        public string Title { get; set; }
        public int MaximumNumberOfMembers { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}