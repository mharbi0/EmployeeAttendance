namespace API.Models
{
    public class JustificationDTO
    {
        public int JustificationId { get; set; }
        public DateTime DateCreated { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
