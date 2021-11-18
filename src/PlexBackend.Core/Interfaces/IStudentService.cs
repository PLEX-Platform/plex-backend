using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IStudentService
    {
        public bool VerifyUserExists(int PCN);
    }
}
