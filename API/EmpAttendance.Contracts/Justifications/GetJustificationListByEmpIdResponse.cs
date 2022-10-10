using API.Models; 

namespace API.EmpAttendance.Contracts.Justifications
{
    public record GetJustificationListByEmpIdResponse (
        List<JustificationDTO> Justifications
    );
}
