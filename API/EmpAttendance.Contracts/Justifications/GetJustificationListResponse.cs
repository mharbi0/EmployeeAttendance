using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.Justifications
{
    public record GetJustificationListResponse (
        List<Justification> Justifications
    );
}
