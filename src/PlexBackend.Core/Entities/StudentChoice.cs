using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.ContextModels
{
    public class StudentChoice
    {
        public int Id { get; set; }
        public int StudentPCN { get; set; }
        public int ProjectId { get; set; }
        public int PriorityRank { get; set; }
    }
}
