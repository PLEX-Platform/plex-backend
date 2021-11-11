using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Validation
{
    public class EnsureUniquePriorityRank : ValidationAttribute
    {
        /// <summary>
        /// Ensure the supplied list of priorityranks doesn't contain duplicate priorityranks
        /// </summary>
        /// <param name="value">The supplied list of ProjectPriorities</param>
        /// <returns>True if the priorityranks in the list occur only once</returns>
        public override bool IsValid(object value)
        {
            List<ProjectPriority> input = value as List<ProjectPriority>
                ;
            if (input.Count == 0)
            {
                return false;
            }

            foreach(ProjectPriority priority in input)
            {
                try
                {
                    input.Single(x => x.PriorityRank == priority.PriorityRank);
                }
                catch(InvalidOperationException ex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}