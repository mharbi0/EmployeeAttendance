using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Justification
    {
        [Key]
        [Display(Name = "Justification ID")]
        public int JustificationId { get; set; }

        [Display(Name = "Date")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeAttendance")]
        public DateTime CheckIn{ get; set; }

        [Display(Name = "Justification")]
        public string Reason { get; set; }

        [Display(Name = "Accepted by Admin")]
        public bool Accepted { get; set; } = false;
    }
}
