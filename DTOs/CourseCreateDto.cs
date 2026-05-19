using System.ComponentModel.DataAnnotations;

namespace SmartLMS.DTOs
{
    // CONCEPT: Data Transfer Object (DTO)
    // Used to transfer data between the View and the Controller securely.
    // CONCEPT: Form Validation & Data Annotations
    public class CourseCreateDto
    {
        [Required(ErrorMessage = "The Course Title is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters.")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 200000, ErrorMessage = "Price must be between Rs. 0 and Rs. 200,000.")]
        public decimal Price { get; set; }
        
        [Required]
        public string CategoryId { get; set; } = string.Empty;
    }
}
