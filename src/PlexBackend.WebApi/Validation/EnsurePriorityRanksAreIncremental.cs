using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Validation
{
    public class EnsurePriorityRanksAreIncremental : ValidationAttribute
    {
        /// <summary>
        /// Ensure entry is greater than 0
        /// </summary>
        /// <param name="input">The integer value of the selection</param>
        /// <returns>True if value is greater than zero</returns>
        public override bool IsValid(object value)
        {
            List<ProjectPriority> input = value as List<ProjectPriority>;
            List<int> priorityranks = new List<int>();

            if (input.Count == 0)
            {
                return false;
            }

            int maxRank = input.Max(p => p.PriorityRank);
            int minRank = input.Min(p => p.PriorityRank);

            if (minRank != 1)
            {
                    return false;
            }

            for (int i = minRank; i <= maxRank; i ++)
            {
                if (input.Find(p => p.PriorityRank == i) == null)
                {
                    return false;
                }
                
            }

            return true;
        }
    }
}