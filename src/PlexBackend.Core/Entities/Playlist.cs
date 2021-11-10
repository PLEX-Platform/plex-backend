using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.ContextModels
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlaylistId { get; set; }
        public int TermId { get; set; }
        public string Name { get; set; }
        public string ProjectsIds { get; set; }
        public int MaxAmountOfChoices { get; set; }
        public DateTime Deadline { get; set; }

        public virtual Term Term { get; set; }

    }
}
