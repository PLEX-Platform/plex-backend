using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.Validation
{
    public class EnsureOneElement : ValidationAttribute
    {
        /// <summary>
        /// Validation method to check if a list contains atleast one object
        /// </summary>
        /// <param name="value">The list to validate.</param>
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}
