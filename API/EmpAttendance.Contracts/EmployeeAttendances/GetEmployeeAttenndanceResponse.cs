using API.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Components.Web;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record GetEmployeeAttenndanceResponse (
        //int EmployeeId,
        //DateTime CheckIn,
        //DateTime? CheckOut, // null: employee has not yet checked out yet
        //bool LateCheckIn,
        //bool EarlyCheckOut
        EmployeeAttendanceDTO EmployeeAttendance
    );
}
