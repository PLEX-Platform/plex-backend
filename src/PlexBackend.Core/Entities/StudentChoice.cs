using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.ContextModels
{
    public class StudentChoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentPCN { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int PriorityRank { get; set; }

        //public Project Project { get; set; }
        //public Student Student { get; set; }
    }
}
