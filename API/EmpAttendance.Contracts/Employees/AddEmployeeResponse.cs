using API.Models;
using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.Employees
{
    public record AddEmployeeResponse(
        //int Id,
        //string Name,
        //bool Admin,
        //bool Active
        EmployeeDTO Employee
    );
}
