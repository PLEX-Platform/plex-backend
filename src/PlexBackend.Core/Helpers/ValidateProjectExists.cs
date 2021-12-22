using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Helpers
{
    public class ValidateProjectExists
    {
        public bool Exists { get; set; }
        public Project Project { get; set; }
    }
}
