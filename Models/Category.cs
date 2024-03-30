using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apidotnet.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The Name field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public required string Name { get; set; }

        [StringLength(200, ErrorMessage = "The Description field must be maximum {1} characters long.")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "The Weight field must be between {1} and {2}.")]
        public int Weight { get; set; }

        [JsonIgnore]
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}
