using API.Models;
using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record GetEmployeeAttenndanceListByEmpIdResponse (
        List<EmployeeAttendanceDTO> Attendances
        );
}
