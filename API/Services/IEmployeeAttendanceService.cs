using API.EmpAttendance.Contracts.EmployeeAttendances;
using DataAccess.Entities;

namespace API.Services
{
    public interface IEmployeeAttendanceService
    {
        Task<bool> CheckIn(EmployeeAttendance attendance);
        Task<bool> CheckOut(EmployeeAttendance attendance);
        Task<List<EmployeeAttendance>> GetEmployeeAttendanceListById(int id);
        Task<EmployeeAttendance> GetEmployeeAttendance(int empId, DateTime checkIn);
        Task<List<EmployeeAttendance>> List();

    }
}