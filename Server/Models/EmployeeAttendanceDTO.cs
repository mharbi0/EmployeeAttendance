namespace Server.Models
{
    public class EmployeeAttendanceDTO
    {
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool LateCheckIn { get; set; } 
        public bool EarlyCheckOut { get; set; } 
    }
}
