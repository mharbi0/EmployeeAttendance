using API.Models;

namespace API.EmpAttendance.Contracts.Employees
{
    public record AddEmployeeRequest(
        //string Name,
        //bool Admin,
        //bool Active
        EmployeeDTO Employee
    );
}
