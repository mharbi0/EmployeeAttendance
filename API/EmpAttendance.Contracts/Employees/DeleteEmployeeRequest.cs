namespace API.EmpAttendance.Contracts.Employees
{
    public record DeleteEmployeeRequest(
        int Id,
        string Name
    );
}
