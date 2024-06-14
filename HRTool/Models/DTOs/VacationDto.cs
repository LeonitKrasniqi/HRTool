using HRTool.Models.Entities;

namespace HRTool.Models.DTOs
{
    public class VacationDto
    {
        public Guid VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

    }
}
