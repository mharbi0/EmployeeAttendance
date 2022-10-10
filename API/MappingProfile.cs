using API.Models;
using AutoMapper;
using DataAccess.Entities;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<EmployeeAttendance, EmployeeAttendanceDTO>();
            CreateMap<EmployeeAttendanceDTO, EmployeeAttendance>();

            CreateMap<Justification, JustificationDTO>();
            CreateMap<JustificationDTO, Justification>();
        }
    }
}
