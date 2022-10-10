using API.Models;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record GetEmployeeAttendanceListResponse (
        List<EmployeeAttendanceDTO> Attendances
    );
}