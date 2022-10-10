using DataAccess.Entities;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record CheckOutResponse (
        string Status,
        bool EarlyCheckOut
    );
}
