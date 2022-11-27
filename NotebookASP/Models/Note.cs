using System.ComponentModel.DataAnnotations;

namespace NotebookASP.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
