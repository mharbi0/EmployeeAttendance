using API.EmpAttendance.Contracts.Employees;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Returns EmployeeId if successfeul; -1 otherwise
        public async Task<int> AddEmployee(Employee employee)
        {
            if (employee.EmployeeId == 0)
            {
                _ = await dbContext.Employees.AddAsync(employee);
                dbContext.SaveChanges();
                return employee.EmployeeId; // Success
            }
            return -1; // Failure
        }

        // Returns null if ID not found
        public async Task<Employee> GetEmployee(int id)
        {
            return await dbContext.Employees.SingleOrDefaultAsync(emp => emp.EmployeeId == id);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var _employee = await dbContext.Employees.SingleOrDefaultAsync(
                emp => emp.EmployeeId == employee.EmployeeId
            );
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Admin = employee.Admin;
                _employee.Active = employee.Active;

                dbContext.Employees.Update(_employee);
                dbContext.SaveChanges();
                return true; // Success
            }
            return false; // Failure
        }

        public async Task<Employee> DeleteEmployee(int id, string name)
        {
            var employee = await dbContext.Employees.SingleOrDefaultAsync(
                emp => emp.EmployeeId == id && emp.Name == name
            );
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                return employee; // Success
            }
            return null; // Failure
        }

        // Returns null if Employees table is empty
        public async Task<List<Employee>> List()
        {
            return await dbContext.Employees.ToListAsync();
        }
    }
}
