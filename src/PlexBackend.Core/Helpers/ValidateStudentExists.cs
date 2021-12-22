using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Helpers
{
    public class ValidateStudentExists
    {
            public bool Exists { get; set; }
            public Student Student { get; set; }
    }
}
