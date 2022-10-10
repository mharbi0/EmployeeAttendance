using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.Justifications
{
    public record GetJustificationListByEmpIdRequest (
        int EmployeeId
    );
}
