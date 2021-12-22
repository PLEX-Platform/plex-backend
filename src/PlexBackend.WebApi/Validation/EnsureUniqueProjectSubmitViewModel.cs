using PlexBackend.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Validation
{
    public class EnsureUniqueProjectSubmitViewModel : ValidationAttribute
    {
        /// <summary>
        /// Ensure the supplied list of priorityranks doesn't contain duplicate priorityranks
        /// </summary>
        /// <param name="value">The supplied list of ProjectPriorities</param>
        /// <returns>True if the priorityranks in the list occur only once</returns>
        public override bool IsValid(object value)
        {
            List<ProjectSubmitViewModel> input = value as List<ProjectSubmitViewModel>
                ;
            if (input.Count == 0)
            {
                return false;
            }

            foreach (ProjectSubmitViewModel project in input)
            {
                try
                {
                    input.Single(x => x.DEXId == project.DEXId);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}
