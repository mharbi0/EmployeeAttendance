using API.Models;
using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.Employees
{
    public record DeleteEmployeeResponse(
        string Status,
        EmployeeDTO Employee
        //int id,
        //string name
    );
}
