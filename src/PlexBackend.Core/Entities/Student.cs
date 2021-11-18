using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.Entities
{
    [Index(nameof(StudentNumber), IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNumber { get; set; }
    }
}