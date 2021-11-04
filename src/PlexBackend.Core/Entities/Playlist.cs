using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.ContextModels
{
    public class Playlist
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public string Name { get; set; }
        public string ProjectsIds { get; set; }
        public int MaxAmountOfChoices { get; set; }
        public DateTime Deadline { get; set; }

        public virtual Term Term { get; set; }

    }
}
