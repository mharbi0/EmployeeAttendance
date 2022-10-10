using API.Models;

namespace API.EmpAttendance.Contracts.Justifications
{
    public record AcceptJustificationRequest(
        //int JustificationId,
        //bool Accepted
        JustificationDTO Justification
    );

}
