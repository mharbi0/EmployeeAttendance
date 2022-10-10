using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Employee : IdentityUser
    {
        [Display(Name = "Employee ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Administrator")]
        public bool Admin { get; set; } = false;

	[Display(Name = "Active")]
        public bool Active { get; set; } = true;
    }
}
