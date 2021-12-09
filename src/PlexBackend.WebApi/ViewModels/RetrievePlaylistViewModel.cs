using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class RetrievePlaylistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExistingProjectViewModel> Projects { get; set; }
        public int MaximumNumberOfStudentsPerProject { get; set; }
    }
}
