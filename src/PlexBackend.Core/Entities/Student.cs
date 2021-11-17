using System.ComponentModel.DataAnnotations;

namespace PlexBackend.Core.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentNumber { get; set; }
    }
}