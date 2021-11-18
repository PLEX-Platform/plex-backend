using PlexBackend.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.ContextModels
{
    public class StudentChoice
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int PriorityRank { get; set; }

        public Project Project { get; set; }
        public Student Student { get; set; }
    }
}
