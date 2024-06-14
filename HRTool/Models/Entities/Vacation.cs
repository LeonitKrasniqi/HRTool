using System.Text.Json.Serialization;

namespace HRTool.Models.Entities
{
    public class Vacation
    {
        public Guid VacationId { get; set; }    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public string Description {  get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }  
    }
}
