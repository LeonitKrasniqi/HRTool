using System.ComponentModel.DataAnnotations;

namespace HRTool.Models.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Salary cannot be 0 or negative.")]
        public double Salary { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Age cannot be 0 or negative.")]
        public int Age { get; set; }
    }
}
