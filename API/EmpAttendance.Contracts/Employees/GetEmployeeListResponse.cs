using API.Models;

namespace API.EmpAttendance.Contracts.Employees
{
    public record GetEmployeeListResponse(
        List<EmployeeDTO> Employees
    );
}
