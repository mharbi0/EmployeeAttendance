using DataAccess.Entities;
using API.EmpAttendance.Contracts.Justifications;

namespace API.Services
{
    public interface IJustificationService
    {
        Task<int> AddJustification (Justification justification);
        Task<Justification> GetJustification(int id);
        Task<List<Justification>> GetJustificationsByEmpId(int employeeId);
        Task<bool> AcceptJustification (int justificationId);
        Task<List<Justification>> List();
    }
}
