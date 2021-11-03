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
        /// Ensure entry is greater than 0
        /// </summary>
        /// <param name="input">The integer value of the selection</param>
        /// <returns>True if value is greater than zero</returns>
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