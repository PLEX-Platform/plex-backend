using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public int DEXId { get; set; }
        public string Title { get; set; }
        public int MaximumNumberOfMembers { get; set; }
    }
}
