using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.ContextModels
{
    public class ProjectGroup
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string StudentPCNs { get; set; }
    }
}
