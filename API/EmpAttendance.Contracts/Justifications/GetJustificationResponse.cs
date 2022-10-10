using API.Models;

namespace API.EmpAttendance.Contracts.Justifications
{
    public record GetJustificationResponse(
        //int JustificationId,
        //int EmployeeId,
        //DateTime CheckIn,
        //DateTime DateCreated,
        //string Reason,
        //bool Accepted
        JustificationDTO Justification
    );
}
