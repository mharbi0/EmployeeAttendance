namespace Server.Models
{
    public class JustificationDTODTO
    {
        public int JustificationDTOId { get; set; }
        public DateTime DateCreated { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
