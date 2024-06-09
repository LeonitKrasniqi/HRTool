using System.Text.Json.Serialization;

namespace HRTool.Models.Entities
{
    public class User
    {
        public Guid UserId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Address {  get; set; }
        public string Gender { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        [JsonIgnore]
        public ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();


    }
}
