using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataAccess.Entities
{
    public class EmployeeAttendance
    {

        // [Key]: Declared using Fluent API (Data/ApplicationDBContext.cs)
        [ForeignKey("Employee")]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        // [Key]: Declared using Fluent API (Data/ApplicationDBContext.cs)
        [Required]
        [Display(Name = "Check In Time")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check Out Time")]
        public DateTime? CheckOut { get; set; }

        [Display(Name = "Late Check In")]
        public bool LateCheckIn { get; set; } = false;

        [Display(Name = "Early Check Out")]
        public bool EarlyCheckOut { get; set; } = false;

    }
}
