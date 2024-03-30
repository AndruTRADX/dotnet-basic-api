using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apidotnet.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public required string Title { get; set; }

        [StringLength(500, ErrorMessage = "The Description field must be maximum {1} characters long.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Priority field is required.")]
        public Priority TaskPriority { get; set; }

        [Required(ErrorMessage = "The CreationDate field is required.")]
        public DateTime CreationDate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [StringLength(200, ErrorMessage = "The Summary field must be maximum {1} characters long.")]
        public string? Summary { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
