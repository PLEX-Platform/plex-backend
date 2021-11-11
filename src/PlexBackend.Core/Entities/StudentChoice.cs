using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
