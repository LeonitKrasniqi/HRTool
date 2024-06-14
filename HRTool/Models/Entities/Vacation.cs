namespace HRTool.Models.Entities
{
    public class Vacation
    {
        public Guid VacationId { get; set; }    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public string Description {  get; set; }
        public Guid UserId { get; set; }
        
        public User User { get; set; }  
        public int VacationDays => (EndDate - StartDate).Days + 1;
    }
}
