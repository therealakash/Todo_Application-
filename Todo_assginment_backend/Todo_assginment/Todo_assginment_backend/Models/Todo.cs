using System.ComponentModel.DataAnnotations;

namespace Todo_assginment.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot morethan 100 characters")]
        [MinLength(3, ErrorMessage = "Add more characters:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "cannot be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Categorize is required")]

        public Categorize Categorize { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public PriorityLevel Priority { get; set; }

    }
}
