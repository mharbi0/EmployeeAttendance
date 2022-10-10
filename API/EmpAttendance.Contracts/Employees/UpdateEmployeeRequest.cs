using API.Models;

namespace API.EmpAttendance.Contracts.Employees
{
    public record UpdateEmployeeRequest(
        //int Id,
        //string Name,
        //bool Admin,
        //bool Active
        EmployeeDTO Employee
    );
}
