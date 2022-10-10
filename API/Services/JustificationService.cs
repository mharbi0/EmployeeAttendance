using API.EmpAttendance.Contracts.Justifications;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class JustificationService : IJustificationService
    {
        private readonly ApplicationDbContext dbContext;

        public JustificationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Returns JustificationId if successfeul; -1 otherwise
        public async Task<int> AddJustification(Justification justification)
        {
            if (justification != null
                && await dbContext.EmpAttendances.SingleOrDefaultAsync( // Checking if EmployeeAttendance record exists
                    att => att.EmployeeId == justification.EmployeeId
                    && att.CheckIn == justification.CheckIn) != null)
            {
                _ = await dbContext.Justifications.AddAsync(justification);
                dbContext.SaveChanges();
                return justification.JustificationId; // Success
            }

            return -1; // Failure
        }
        public async Task<Justification> GetJustification(int id)
        {
            return await dbContext.Justifications.SingleOrDefaultAsync(
                e => e.JustificationId == id
            );
        }

        public async Task<List<Justification>> GetJustificationsByEmpId(int employeeId)
        {
            return await dbContext.Justifications.Where(
                e => e.EmployeeId == employeeId
                ).ToListAsync();
        }

        public async Task<bool> AcceptJustification(int justificationId)
        {
            var justification = await dbContext.Justifications.SingleOrDefaultAsync(
                e => e.EmployeeId == justificationId
            );

            if (justification != null)
            {
                justification.Accepted = true;

                dbContext.Justifications.Update(justification);
                dbContext.SaveChanges();
                return true; // Success
            }
            return false; // Failure
        }
        public async Task<List<Justification>> List()
        {
            return await dbContext.Justifications.ToListAsync();
        }
    }
}
