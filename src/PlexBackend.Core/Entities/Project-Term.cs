using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.ContextModels
{
    public class Project_Term
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public int ProjectId { get; set; }

        public virtual Term Term { get; set; }
    }
}
