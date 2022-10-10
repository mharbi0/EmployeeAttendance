using API.Models;

namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record CheckOutRequest(
        //int EmpId,
        //DateTime CheckIn,
        //DateTime CheckOut
        EmployeeAttendanceDTO EmployeeAttendance
    );
}
