using API.Models;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record CheckInResponse (
        int StatusCode,
        string Status,
        bool LateCheckIn
    );
}
