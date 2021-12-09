using PlexBackend.WebApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class ExistingProjectViewModel
    {
        public int Id { get; set; }
        public int DEXId { get; set; }
        public string Title { get; set; }
    }
}
