using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Validation
{
    public class RequiredGreaterThanZero : ValidationAttribute
    {
        /// <summary>
        /// Ensure entry is greater than 0
        /// </summary>
        /// <param name="value">The integer value of the selection</param>
        /// <returns>True if value is greater than zero</returns>
        public override bool IsValid(object value)
        {
            // return true if value is a non-null number > 0, otherwise return false
            int i;
            return value != null && int.TryParse(value.ToString(), out i) && i > 0;
        }
    }
}
