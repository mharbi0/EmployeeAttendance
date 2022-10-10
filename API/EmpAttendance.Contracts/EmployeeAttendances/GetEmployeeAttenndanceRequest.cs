namespace API.EmpAttendance.Contracts.EmployeeAttendances
{
    public record GetEmployeeAttenndanceRequest (
        int EmployeeId,
        DateTime CheckIn
    );
}
