using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.ContextModels
{
    public class ProjectGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectGroupId { get; set; }
        public int ProjectId { get; set; }
        public string StudentPCNs { get; set; }
    }
}
