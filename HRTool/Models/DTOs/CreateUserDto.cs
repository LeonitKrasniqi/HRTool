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
        public string Email { get; set; }
        [Required]
            
        public int Salary { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
