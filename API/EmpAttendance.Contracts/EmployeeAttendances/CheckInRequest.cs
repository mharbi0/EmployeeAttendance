using API.Models;
namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record CheckInRequest (
        //int EmployeeId,
        //DateTime CheckIn
        EmployeeAttendanceDTO EmployeeAttendance
    );
}
