using API.Models;

namespace API.EmpAttendance.Contracts.Justifications
{
    public record AddJustificationRequest (
        //int EmpId,
        //DateTime CheckIn,
        //string Reason
        JustificationDTO Justification
    );
}
