using System.ComponentModel.DataAnnotations;

namespace HRTool.Models.DTOs
{
    public class RequestVacationDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
