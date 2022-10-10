using API.EmpAttendance.Contracts.Employees;
using API.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;
using AutoMapper;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeesService employeesService, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeesService = employeesService;
            _logger = logger;
            _mapper = mapper;
        }

        // POST api/employee/
        [ProducesDefaultResponseType(typeof(AddEmployeeResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
        {
            if (request.Employee == null)
                return BadRequest();
            try
            {
                var employee = _mapper.Map<Employee>(request.Employee);
                employee.EmployeeId = await _employeesService.AddEmployee(employee);
                if (employee.EmployeeId <= 0)
                {
                    return BadRequest();
                };
                return CreatedAtAction(
                    actionName: nameof(GetEmployee),
                    routeValues: new { ID = employee.EmployeeId },
                    value: new AddEmployeeResponse(
                        _mapper.Map<EmployeeDTO>(employee)));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(AddEmployee)}");
                return Problem();
            }
        }

        // GET api/employee/{id}
        [ProducesDefaultResponseType(typeof(GetEmployeeResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeesService.GetEmployee(id);
                if (employee == null)
                    return NotFound();
                var result = _mapper.Map<EmployeeDTO>(employee);
                return Ok(new GetEmployeeResponse(result));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetEmployee)}");
                return Problem();
            }
        }

        // PUT api/employee/
        [ProducesDefaultResponseType(typeof(UpdateEmployeeResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest request)
        {
            if (request.Employee == null)
                return BadRequest();
            try
            {
                var employee = _mapper.Map<Employee>(request.Employee);
                if (await _employeesService.UpdateEmployee(employee))
                    return Ok(new UpdateEmployeeResponse(
                            Status: "Success"));

                return NotFound(new UpdateEmployeeResponse(
                            Status: "Failure: Employee not found"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(UpdateEmployee)}");
                return Problem();
            }
        }

        // DELETE api/employee/{id}
        [ProducesDefaultResponseType(typeof(DeleteEmployeeResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id, DeleteEmployeeRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var employee = await _employeesService.DeleteEmployee(request.Id, request.Name);
                if (employee != null)
                    return Ok(new DeleteEmployeeResponse(
                        Status: "Success",
                        Employee: _mapper.Map<EmployeeDTO>(employee)));
                return NotFound(new DeleteEmployeeResponse(
                        Status: "Failure: Employee not found",
                        Employee: null));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(DeleteEmployee)}");
                return Problem();
            }
        }

        // GET api/employee/employeelist
        [ProducesDefaultResponseType(typeof(GetEmployeeListResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var employees = await _employeesService.List();
                if (employees != null)
                    return Ok(new GetEmployeeListResponse(
                        Employees: _mapper.Map<List<EmployeeDTO>>(employees)));

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(List)}");
                return Problem();
            }
        }
    }
}
