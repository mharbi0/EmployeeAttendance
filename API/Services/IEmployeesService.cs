using API.EmpAttendance.Contracts.Employees;
using DataAccess.Entities;

namespace API.Services
{
    public interface IEmployeesService
    {
        //Task<Employee> AddEmployee(AddEmployeeRequest request);
        //Task<Employee> GetEmployee(GetEmployeeRequest request);
        //Task<Employee> UpdateEmployee(UpdateEmployeeRequest request);
        //Task<Employee> DeleteEmployee(DeleteEmployeeRequest request);

        // Returns created Employee ID
        Task<int> AddEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);
        Task<bool> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id, string name);
        Task<List<Employee>> List();

    }
}
