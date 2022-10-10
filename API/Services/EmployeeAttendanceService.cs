using API.EmpAttendance.Contracts.EmployeeAttendances;
using DataAccess.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeAttendanceService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Returns true when CheckIn process is successful; false otherwise
        public async Task<bool> CheckIn(EmployeeAttendance attendance)
        {
            if (attendance != null
                && await dbContext.Employees.FindAsync(attendance.EmployeeId) != null) // Checking if Employee exists
            {
                _ = await dbContext.EmpAttendances.AddAsync(attendance);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> CheckOut(EmployeeAttendance attendance)
        {
            var _attendance = await dbContext.EmpAttendances.SingleOrDefaultAsync(
                e => e.EmployeeId == attendance.EmployeeId && e.CheckIn == attendance.CheckIn
            );

            if (_attendance != null)
            {
                _attendance.CheckOut = attendance.CheckOut;

                dbContext.EmpAttendances.Update(_attendance);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<EmployeeAttendance> GetEmployeeAttendance(int id, DateTime checkIn)
        {
            return await dbContext.EmpAttendances.SingleOrDefaultAsync(
                    e => e.EmployeeId == id && e.CheckIn == checkIn);
        }

        public async Task<List<EmployeeAttendance>> GetEmployeeAttendanceListById(int id)
        {
            return await dbContext.EmpAttendances.Where(
                    att => att.EmployeeId == id ).ToListAsync();
        }
        public async Task<List<EmployeeAttendance>> List()
        {
            return await dbContext.EmpAttendances.ToListAsync();
        }
    }
}
