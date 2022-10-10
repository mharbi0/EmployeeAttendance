using API.EmpAttendance.Contracts.EmployeeAttendances;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using API.EmpAttendance.Contracts.Employees;
using AutoMapper;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IEmployeeAttendanceService _employeeAttendanceService;
        private readonly ILogger<EmployeeAttendanceController> _logger;
        private readonly IMapper _mapper;

        public EmployeeAttendanceController(IEmployeeAttendanceService employeeAttendanceService, ILogger<EmployeeAttendanceController> logger, IMapper mapper)
        {
            _employeeAttendanceService = employeeAttendanceService;
            _logger = logger;
            _mapper = mapper;
        }

        // POST /EmployeeAttendances/CheckIn
        [ProducesDefaultResponseType(typeof(CheckInResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CheckIn")]
        public async Task<IActionResult> CheckIn(CheckInRequest request)
        {
            try
            {
                var attendance = _mapper.Map<EmployeeAttendance>(request.EmployeeAttendance);
                if (attendance.CheckIn.Hour < 7) // CheckIn not available yet
                    return Unauthorized(new CheckInResponse(StatusCode: -1,
                                                            Status: "Checking in before 7AM is not allowed",
                                                            LateCheckIn: false));
                if (attendance.CheckIn.Hour > 9
                    || (attendance.CheckIn.Hour > 8 && attendance.CheckIn.Hour > 29))
                    attendance.LateCheckIn = true;

                if (!await _employeeAttendanceService.CheckIn(attendance)) // CheckIn was not successful
                    return BadRequest();

                return CreatedAtAction(
                    actionName: nameof(GetEmployeeAttendance),
                    routeValues: new
                    {
                        EmployeeId = attendance.EmployeeId,
                        CheckIn = attendance.CheckIn
                    },
                    value: new CheckInResponse(StatusCode: 1,
                                               Status: "Success",
                                               LateCheckIn: attendance.LateCheckIn));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(CheckIn)}");
                return Problem();
            }
        }

        // PUT /EmployeeAttendances/CheckOut/
        [ProducesDefaultResponseType(typeof(CheckOutResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("CheckOut")]
        public async Task<IActionResult> CheckOut(CheckOutRequest request)
        {
            try
            {
                if (!(request.EmployeeAttendance.CheckOut.GetType() == typeof(DateTime)))
                    return BadRequest();

                var attendance = _mapper.Map<EmployeeAttendance>(request.EmployeeAttendance);
                if (((DateTime)attendance.CheckOut).Hour < 15)
                    attendance.EarlyCheckOut = true;

                if (!await _employeeAttendanceService.CheckOut(attendance))
                    return NotFound();

                return Ok(new CheckOutResponse(
                        Status: "Success",
                        EarlyCheckOut: attendance.EarlyCheckOut));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(CheckOut)}");
                return Problem();
            }
        }

        // GET /EmployeeAttendances/
        [ProducesDefaultResponseType(typeof(GetEmployeeAttenndanceResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeAttendance(GetEmployeeAttenndanceRequest request)
        {
            try
            {
                var attendance = await _employeeAttendanceService.GetEmployeeAttendance(request.EmployeeId, request.CheckIn);
                if (attendance != null)
                    return Ok(new GetEmployeeAttenndanceResponse(
                        EmployeeAttendance: _mapper.Map<EmployeeAttendanceDTO>(attendance)));

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetEmployeeAttendance)}");
                return Problem();
            }
        }

        // GET /EmployeeAttendances/Employee/{{EmployeeId}}
        [ProducesDefaultResponseType(typeof(GetEmployeeAttenndanceListByEmpIdResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Employee/{id:int}")]
        public async Task<IActionResult> GetEmployeeAttendanceListByEmployeeId(int id)
        {
            try
            {
                var attendances = await _employeeAttendanceService.GetEmployeeAttendanceListById(id);
                if (attendances != null)
                    return Ok(new GetEmployeeAttenndanceListByEmpIdResponse(
                        Attendances: _mapper.Map<List<EmployeeAttendanceDTO>>(attendances)));

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetEmployeeAttendanceListByEmployeeId)}");
                return Problem();
            }
        }


        // GET /EmployeeAttendances/List
        [ProducesDefaultResponseType(typeof(GetEmployeeAttendanceListResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var attendances = await _employeeAttendanceService.List();
                if (attendances != null)
                    return Ok(new GetEmployeeAttendanceListResponse(
                        Attendances: _mapper.Map<List<EmployeeAttendanceDTO>>(attendances)));

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetEmployeeAttendanceListByEmployeeId)}");
                return Problem();
            }
        }
    }
}
